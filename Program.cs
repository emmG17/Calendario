class Program {    
    
    private static string ReadWrite(string instruccion){
        Console.Write($"> {instruccion}: ");
        string? input = Console.ReadLine();
        return input ?? "N/A";
    }

    public static void Main(){
        // Obtener input
        string nombreMes = ReadWrite("Nombre del mes");
        string diasMes = ReadWrite("Cantidad de dias");        
        string estiloBorde = ReadWrite("Estilo de borde");
        string primerDia = ReadWrite("Primer dia del mes");

        Console.Clear();

        // Obtener el item correspondiente del enum que contiene los dias a partir de la cadena de texto ingresada
        Dias diaInicial = (Dias) Enum.Parse(typeof(Dias), primerDia.Trim().ToLower());
        int cantidadDias = Int32.Parse(diasMes);
        char borde = estiloBorde[0];

        // Instanciar el objeto Mes para visualizar el calendario
        Mes mes = new Mes(nombreMes, borde);
        mes.cantidadDias = cantidadDias;
        mes.diaInicial = diaInicial;

        // Mostrar el calendario
        mes.PresentarCalendario();
    }
}
