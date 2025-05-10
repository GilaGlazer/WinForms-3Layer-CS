
namespace DO;
//חריגה עבור ישות עם מספר מזהה שלא קיים ברשימה
[Serializable]
public  class DalIdNotExistExeption :Exception
{
    public DalIdNotExistExeption(String type)
    {
        throw new Exception($"id does not exist - {type}");
    }
}

//חריגה עבור ישות עם מספר מזהה שכבר קיים ברשימה
[Serializable]
public class DalIdExistExeption : Exception
{
    public DalIdExistExeption(String type)
    {
        throw new Exception($"id already exist - {type}");
    }
}

//חריגה עבור ישות שהיא NULL
[Serializable]
public class DalNullObjectExeption : Exception
{
    public DalNullObjectExeption(String type)
    {
        throw new Exception($"null recived - {type}");
    }
}

//שגיאה בכתיבה לXML
[Serializable]
public class DalWriteToXmlExeption : Exception
{
    public DalWriteToXmlExeption(String type)
    {
        throw new Exception($"error in write to xml - {type}");
    }
}

//שגיאה בקריאה לXML
[Serializable]
public class DalReadFromXmlExeption : Exception
{
    public DalReadFromXmlExeption(String type)
    {
        throw new Exception($"error in read from xml - {type}");
    }
}

//שגיאות כלליות
[Serializable]
public class DalGeneralExeption : Exception
{
    public DalGeneralExeption(String type,String nameFunc)
    {
        throw new Exception($"error in - {type} in function: {nameFunc}");
    }
}



