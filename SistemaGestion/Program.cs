using SistemaGestion.ADO;


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
        "5- Ver lista de...\n" +
        "0- SALIR" 
    );

    op = Convert.ToInt32(Console.ReadLine());

    Console.Clear();

    switch (op)
    {
        case 1:
            Console.WriteLine("Nombre de usuario: ");
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
            if (ADO.Session(user, pass))
            { Console.WriteLine("Sesion iniciada"); }
            else { Console.WriteLine("Sesion no iniciada"); }
            break;


        case 5:
            int op2 = 0;
            Console.WriteLine(
                "------MENU------\n" +
                "1- Ver usuarios\n" +
                "2- Ver productos\n" +
                "3- Ver productos vendidos\n" +
                "4- Ver ventas\n" +
                "0- SALIR"
            );
            op2 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (op2){
                case 1: ADO_Listas.GetUsuarios();
                    break;
                case 2: ADO_Listas.GetProductos();
                    break;
                case 3: ADO_Listas.GetProductosVendidos();
                    break;
                case 4: ADO_Listas.GetVentas();
                    break;
                default: op2 = 0;
                    break;
            }
            break;


        default:
            op = 0;
            break;
    }
    Console.ReadKey();
    Console.Clear();
} while (op != 0);


