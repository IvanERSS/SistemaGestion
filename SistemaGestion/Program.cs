using SistemaGestion.ADO;
using System.Data.SqlClient;
using System.Reflection.Metadata;


int op = 0;
string user, pass;
do
{
    string parametro = "";
    Console.WriteLine(
        "------MENU------\n" + 
        "1- Ver usuario\n" +
        "2- Ver ventas por usuario\n" +
        "3- Ver lista de productos vendidos por usuario\n" +
        "4- Iniciar sesion\n" +
        "0- SALIR"
    );

    op = Convert.ToInt32(Console.ReadLine());

    Console.Clear();

    switch (op)
    {
        case 1:
            Console.WriteLine("Nombre a buscar: ");
            parametro = Convert.ToString(Console.ReadLine());
            ADO.GetUsuarios(parametro); 
            break;
        case 2:
            Console.WriteLine("ID de usuario: ");
            parametro = Convert.ToString(Console.ReadLine());
            ADO.GetProductos(parametro);
            break;
        case 3:
            Console.WriteLine("Nombre de usuario: ");
            parametro = Convert.ToString(Console.ReadLine());
            ADO.GetProductosVendidos(parametro);
            break;
        case 4:
            Console.WriteLine("Nombre de usuario: ");
            user = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Contrasenia: ");
            pass = Convert.ToString(Console.ReadLine());
            if (ADO.Session(user,pass)) 
            { Console.WriteLine("Sesion iniciada"); }
            else { Console.WriteLine("Sesion no iniciada"); }
            break;
        default: op = 0; 
            break;
    }
    Console.ReadKey(); 
    Console.Clear();
} while (op != 0);


