using System.Configuration;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

internal partial class Program
{

    private static void Main(string[] args)
    {
        Storoom db = new Storoom(ConfigurationManager.ConnectionStrings["connStoroom"].ConnectionString);
        db.GetCommand();
    }
}