

namespace BO;

//חריגה עבור ישות עם מספר מזהה שלא קיים ברשימה
[Serializable]
public class BlIdNotExistExeption : Exception
{
    public BlIdNotExistExeption(String? messege):base(messege) { }
    public BlIdNotExistExeption(string message, Exception innerException)
    : base(message, innerException) { }
}

//חריגה עבור ישות עם מספר מזהה שכבר קיים ברשימה
[Serializable]
public class BlIdExistExeption : Exception
{
    public BlIdExistExeption(String? messege) : base(messege) { }
    public BlIdExistExeption(string message, Exception innerException)
    : base(message, innerException) { }
}
//חריגה עבור ישות שהיא NULL
[Serializable]
public class BlNullObjectExeption : Exception
{
    public BlNullObjectExeption(String? messege) : base(messege) { }
    public BlNullObjectExeption(string message, Exception innerException)
    : base(message, innerException) { }
}

//שגיאה בכתיבה לXML
[Serializable]
public class BlWriteToXmlExeption : Exception
{
    public BlWriteToXmlExeption(String? messege) : base(messege) { }
    public BlWriteToXmlExeption(string message, Exception innerException)
    : base(message, innerException) { }
}

//שגיאה בקריאה לXML
[Serializable]
public class BlReadFromXmlExeption : Exception
{
    public BlReadFromXmlExeption(String? messege) : base(messege) { }
    public BlReadFromXmlExeption(string message, Exception innerException)
    : base(message, innerException) { }
}

//שגיאות כלליות
[Serializable]
public class BlGeneralExeption : Exception
{
    public BlGeneralExeption(String? messege1, String? messege) : base(messege) { }
    public BlGeneralExeption(string message, Exception innerException)
    : base(message, innerException) { }
}

//קלט לא תקין
[Serializable]
public class BlInputNotCorrectExeption : Exception
{
    public BlInputNotCorrectExeption(String? messege) : base(messege) { }
    public BlInputNotCorrectExeption(string message, Exception innerException)
    : base(message, innerException) { }
}

