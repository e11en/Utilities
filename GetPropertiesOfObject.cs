/// <summary>
/// Get an XML string representation of an objects properties.
/// </summary>
/// <param name="item">The object itself.</param>
/// <returns>XML string</returns>
public string GetXmlOfObject(object item) {
  var builder = new System.Text.StringBuilder();
  builder.Append("<ROOT>");

  // Loop through all properties
  foreach (var item in properties)
  {
      // properties from an item
      foreach (var prop in GetPropertiesOfObject(item))
      {
          builder.Append($"<{prop.Key}>");
          if (prop.Value is string)
          {
              builder.Append($"{prop.Value}");
          }
          else
          {
              // If the data is an object as well then loop through those properties as well
              foreach (var innerProp in GetPropertiesOfObject(prop.Value))
              {
                  builder.Append(string.Format("<{0}>{1}</{0}>", innerProp.Key, innerProp.Value));
              }
          }

          builder.Append($"</{prop.Key}>");
      }
  }
  builder.Append($"</ROOT>");

  return builder.ToString();
}

/// <summary>
/// Get the properties of an object.
/// </summary>
/// <param name="value">The object to get the properties from.</param>
/// <returns>Dictionary where key is name of property and value is the value of the property.</returns>
private static Dictionary<string, object> GetPropertiesOfObject(object value)
{
    var properties = new Dictionary<string, object>();
    foreach (var prop in value.GetType().GetProperties())
    {
        var propValue = prop.GetValue(value, null);
        if (propValue != null)
        {
            properties.Add(prop.Name, propValue);
        }
    }
    return properties;
}
