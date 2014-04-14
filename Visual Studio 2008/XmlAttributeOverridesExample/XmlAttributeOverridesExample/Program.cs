using System;
using System.IO;
using System.Xml.Serialization;

public class CityGroup
{
    [XmlArrayItemAttribute(ElementName = "CityGroupIds",)]
    public CityGroupId[] CityGroupIds = new CityGroupId[4];
}

public struct CityGroupId
{
    public string Value;
}

public class Run
{
    public static void Main()
    {
        CityGroup cityGroup = new CityGroup();

        cityGroup.CityGroupIds[0].Value = "Pepito1";
        cityGroup.CityGroupIds[1].Value = "Pepito2";
        cityGroup.CityGroupIds[2].Value = "Pepito3";
        cityGroup.CityGroupIds[3].Value = "Pepito4";

        // Insert code to set properties and fields of the object.
        XmlSerializer mySerializer = new
        XmlSerializer(typeof(CityGroup));

        // To write to a file, create a StreamWriter object.
        StreamWriter myWriter = new StreamWriter("myFileName.xml");
        mySerializer.Serialize(myWriter, cityGroup);
        myWriter.Close();
    }
}