/// <summary>
/// Any class that implements this interface will contain 
/// an array of subjects. This way the Game Manager can ex:
/// reference anything that has subjects to train
/// </summary>
public interface ISubjectHolder
{
    public SubjectObject[] Subjects { get; }
}
