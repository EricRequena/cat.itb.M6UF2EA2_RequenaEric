//Npgsql .NET Data Provider for PostgreSQL
using UF2_test.cruds;
using UF2_test.model; 

class Program
{
   static void Main(string[] args) {
        AsignaturasCRUD crud = new AsignaturasCRUD();
        // crud.SelectVersion();
        // crud.SelectAllSubjects1();
        //   crud.SelectAllSubjects2();
        //  crud.SelectSubjectPS();
        //  crud.InsertSubject();
        // crud.DeleteSubject(7);
        //  crud.DeleteSubject(8);
        // crud.InsertSubjectPS();
        //  crud.DeleteSubjectPS(6);
        //crud.InsertMoreThanOneSubjectPS();

        //SelectAllSubjects();
        // SelectOneSubject(3);

        var subject = new Asignatura
        {
            cod = 20,
            nombre = "FÍSICA"
        };

        crud.InsertSubjectPS2(subject);

        //SelectAllSubjects();

        //InsertSubject();
       // SelectAllSubjects();
        //UpdateSubject(20, "BIOLOGIA");
         //SelectAllSubjects();

    }

    private static void SelectAllSubjects()
    {
        AsignaturasCRUD crud = new AsignaturasCRUD();
        List<Asignatura> subjects = crud.SelectAllSubjects3();
   
        foreach (Asignatura subject in subjects)
        {
            Console.WriteLine("Codi:{0} "+ "Nom:{1} ",subject.cod , subject.nombre);
        }
    }
    
    private static void SelectOneSubject(int codi)
    {
        AsignaturasCRUD crud = new AsignaturasCRUD();
        Asignatura subject = crud.SelectSubjectPS2(codi);
        Console.WriteLine("Codi:{0} "+ "Nom:{1} ",subject.cod , subject.nombre);

    }
    
    public static void UpdateSubject(int pcodi, string pnom) 
    {
        AsignaturasCRUD crud = new AsignaturasCRUD();
        var subject = crud.SelectSubjectPS2(pcodi);
        subject.nombre = pnom;
        crud.DeleteSubject(pcodi);
       crud.InsertSubjectPS2(subject);

        Console.WriteLine("row updated");       
    }
}


