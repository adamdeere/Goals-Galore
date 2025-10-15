namespace GoalsGalore.Model;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class WizardAttributes
{
    public string Slug { get; set; }
    public List<string> Alias_names { get; set; }
    public object Animagus { get; set; }
    public string Blood_status { get; set; }
    public object Boggart { get; set; }
    public string Born { get; set; }
    public string Died { get; set; }
    public string Eye_color { get; set; }
    public List<string> Family_members { get; set; }
    public string Gender { get; set; }
    public string Hair_color { get; set; }
    public string Height { get; set; }
    public string House { get; set; }
    public string Image { get; set; }
    public List<string> Jobs { get; set; }
    public string Marital_status { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public string Patronus { get; set; }
    public List<string> Romances { get; set; }
    public string Skin_color { get; set; }
    public string Species { get; set; }
    public List<string> Titles { get; set; }
    public List<string> Wands { get; set; }
    public object Weight { get; set; }
    public string Wiki { get; set; }
}

public class Datum
{
    public string? Id { get; set; }
    public string? Type { get; set; }
    public WizardAttributes? Attributes { get; set; }
    public Links? Links { get; set; }
}

public class Links
{
    public string self { get; set; }
    public string current { get; set; }
    public string next { get; set; }
    public string last { get; set; }
}

public class Meta
{
    public Pagination pagination { get; set; }
    public string copyright { get; set; }
    public DateTime generated_at { get; set; }
}

public class Pagination
{
    public int current { get; set; }
    public int next { get; set; }
    public int last { get; set; }
    public int records { get; set; }
}

public class CharacterRoot
{
    public List<Datum> Data { get; set; }
    public Meta Meta { get; set; }
    public Links Links { get; set; }
}