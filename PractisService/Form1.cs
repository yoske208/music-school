using static MusicSchool.Service.MusicSchoolService;
namespace PractisService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXmlIfNotExist();
            InsertClassRoom("Geitar");
            AddTecher("Geitar", "yos");
            AddStudent("Geitar", "yos", "Tof");
        }
    }
    }
