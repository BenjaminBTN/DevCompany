using System.Collections;

namespace DepartmentService.Shared;

public class Errors : IEnumerable<Error>
{
    private const string SEPARATOR = "&&";
    private readonly List<Error> _errors;

    public Errors()
    {
        _errors = [];
    }

    public Errors(IEnumerable<Error> errors)
    {
        _errors = errors.ToList();
    }

    public IEnumerator<Error> GetEnumerator()
    {
        return _errors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #region Дополнительные методы
    public string Serialize()
    {
        List<string> errorsString = [];
        foreach (var error in _errors)
        {
             errorsString.Add(error.Serialize());
        }
        return string.Join(SEPARATOR, errorsString);
    }

    public static List<Error> Deserialize(string serializedSting)
    {
        string[] parts = serializedSting.Split(SEPARATOR);
        if (parts.Length == 0)
            throw new ArgumentNullException(nameof(serializedSting));

        List<Error> errors = [];

        foreach (string part in parts)
        {
            errors.Add(Error.Deserialize(part));
        }
        return errors;
    }
    #endregion
}
