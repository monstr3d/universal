using System;
using System.Xml;
using System.Collections;
using System.Runtime.Serialization;

using CategoryTheory;


using BaseTypes;


using Localization.Helper;
using NamedTree;


namespace Regression.Portable;

/// <summary>
/// Selection constructed from xml
/// </summary>
[Serializable()]
public class XmlSelectionCollection : ArraySelectionCollection, ISerializable, ICategoryObject
{

	#region Fields

	CategoryTheory.Performer performer = new();


    /// <summary>
    /// Associated object
    /// </summary>
    protected object obj;

        /// <summary>
        /// Related docuiment
        /// </summary>
	protected XmlDocument document;

        /// <summary>
        /// Scheme
        /// </summary>
	protected XmlDocument scheme;

        /// <summary>
        /// String representastion of document
        /// </summary>
	protected string documentString;

        /// <summary>
        /// String representastion of scheme
        /// </summary>
        protected string schemeString;

	#endregion

	#region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
 		public XmlSelectionCollection()
	{
	}

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public XmlSelectionCollection(SerializationInfo info, StreamingContext context)
	{
		documentString = info.GetValue("Document", typeof(string)) as string;
		schemeString = info.GetValue("Scheme", typeof(string)) as string;
		load();
	}

	#endregion

	#region ISerializable Members


        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("Document", documentString);
		info.AddValue("Scheme", schemeString);
	}

	#endregion

	#region ICategoryObject Members

        /// <summary>
        /// The identical arrow of this object
        /// </summary>
        public ICategoryArrow Id
	{
		get
		{
			return null;
		}
	}

        /// <summary>
	#endregion

	#region IAssociatedObject Members

        /// <summary>
        /// The associated object
        /// </summary>
        public object Object
	{
		get
		{
			return obj;
		}
		set
		{
			obj = value;
		}
	}

	#endregion

	#region Specific Members

        /// <summary>
        /// String representation of Xml document
        /// </summary>
	public string Document
	{
		get
		{
			return documentString;
		}
		set
		{
			documentString = value;
			load();
		}
	}

        /// <summary>
        /// String representation of scheme
        /// </summary>
	public string Scheme
	{
		get
		{
			return schemeString;
		}
		set
		{
			schemeString = value;
			load();
		}
	}

    object IAssociatedObject.Object { get ; set; }
    string INamed.Name { get => performer.GetAssociatedName(this); set =>new  ErrorHandler.WriteProhibitedException(); }
   

    void load()
	{
		if (documentString == null | schemeString == null)
		{
			return;
		}
		try
		{
			document = new XmlDocument();
			document.LoadXml(documentString);
			scheme = new XmlDocument();
			scheme.LoadXml(schemeString);
			XmlElement parametersDescription = 
				scheme.GetElementsByTagName("ParametersDescription")[0] as XmlElement;
			string strParametersDescription = 
				parametersDescription.Attributes["value"].Value;
			string strId = parametersDescription.Attributes["id"].Value;
			string strName = parametersDescription.Attributes["name"].Value;
			XmlElement docParametersDescription =
				document.GetElementsByTagName(strParametersDescription)[0] as XmlElement;
			string strParameterDescription = 
				parametersDescription.Attributes["ParameterDescription"].Value;
			XmlNodeList parametesDescriptions = 
				docParametersDescription.GetElementsByTagName(strParameterDescription);
		
			string[] names = new string[parametesDescriptions.Count];
			Hashtable ids = new Hashtable();
			int i = 0;
			ArrayList cNames = new ArrayList();
			foreach (XmlElement e in parametesDescriptions)
			{
				string id = e.Attributes[strId].Value;
				string name = e.Attributes[strName].Value;
				if (ids.ContainsKey(id))
				{
					throw new ErrorHandler.OwnException("Id " + id + " already exists");
				}
				if (cNames.Contains(name))
				{
					throw new ErrorHandler.OwnException("Name " + name + " already exists");
				}
				ids[id] = i;
				cNames.Add(name);
				names[i] = name;
				++i;
			}
			XmlElement parametersDictionary =
				parametersDescription.GetElementsByTagName("ParameterDictionary")[0] as XmlElement;
			string strValue = parametersDictionary.Attributes["value"].Value;
			string strParameter = parametersDictionary.Attributes["Parameter"].Value;
			string strResults = parametersDictionary.Attributes["Results"].Value;
			string strResult = parametersDictionary.Attributes["Result"].Value;
			XmlElement docResults = document.GetElementsByTagName(strResults)[0] as XmlElement;
			XmlNodeList listResults = docResults.GetElementsByTagName(strResult);
			double[][] data = new double[names.Length][];
			for (int j = 0; j < data.Length; j++)
			{
				data[j] = new double[listResults.Count];
			}
			for (int j = 0; j < listResults.Count; j++)
			{
				XmlElement result = listResults[j] as XmlElement;
				XmlNodeList par = result.GetElementsByTagName(strParameter);
				foreach (XmlElement e in par)
				{
					string id = e.Attributes[strId].Value;
					int n = (int) ids[id];
                        data[n][j] = e.GetAttribute(strValue).Convert();
				}
			}
			Set(names, data);
		}
		catch (Exception e)
		{
			documentString = null;
			schemeString = null;
			throw e;
		}
	}

	#endregion
}
