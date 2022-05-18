using System.Windows.Forms;

namespace Generator.Controllers
{
  public class Generator
  {
    private readonly FormGenerator _frmGen;
    private readonly FormGenerator _frmMap;


    public Generator()
    {
      _frmGen = new FormGenerator();
      Application.Run(_frmGen);
    }

    public static void Main(string[] args)
    {
      new Generator();
    }
  }
}