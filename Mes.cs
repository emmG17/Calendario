class Mes {

    const int ANCHO = 50;    
    public int cantidadDias { get; set; }
    public Dias diaInicial { get; set; }
    private string nombreMes;
    private char borde;
    private string separadorFilas;
    
    
    public Mes(string nombre, char borde) {
        this.nombreMes = nombre;
        this.borde = borde;
        this.separadorFilas = new string(borde, ANCHO);
    }


    private void Encabezado(){
        // Agregar los bordes inicial y final, en medio escribir el nombre del mes
        string filaNombre = borde + StringHelper.PadCenter(nombreMes, ' ', ANCHO - 2) + borde;
        Console.Write(separadorFilas + "\n" + filaNombre +"\n" +  separadorFilas + "\n");
    }

    private void EncabezadoDias(){
        // Borde inicial del encabezado con el nombre de los dias
        string encabezadoDias = borde.ToString();

        // Iterar los 7 dias de la semana
        for (int i = 0; i < 7; i++){
            // Obtener el texto del enum que contiene los dias
            string dia = ((Dias)i).ToString();
            // Crear la abreviacion de los dias obteniendo las dos primeras letras en mayusculas
            string simboloDia = dia.Substring(0,2).ToUpper();
            // Agregar espacio suficiente entre el dia y los bordes
            encabezadoDias += StringHelper.PadCenter(simboloDia, ' ', 6) + borde;
        }
        Console.Write(encabezadoDias + "\n" + separadorFilas + "\n");
    }

    private void Semana(int offsetInicial, int nSemana){
        string semana  = ""; // Cadena que recibira cada casilla de dia de la semana

        // iterar 3 veces para obtener una altura de 3 caracteres
        for (int i = 0; i < 3; i++){ 
            // Agregar el borde inicial
            semana += borde;
            // Crear una casilla por cada dia de la semana
            for (int j = 0; j < 7; j++){
                // Si es la segunda fila de la casill, imprimir el numero de dia
                if (i == 1){
                    // Calcular el dia del mes tomando en cuenta que dia inicio
                    int dia = (nSemana * 7) + j + 1 - offsetInicial;
                    // si el dia esta dentro del rango y es mayor a 0 desplegarlo
                    if (dia <= cantidadDias && dia > 0){
                        semana += StringHelper.PadCenter(dia.ToString("D2"), ' ', 6) + borde;
                        continue;
                    }  
                }
                // Llenar la fila con espacios vacios y un borde a la derecha
                semana += StringHelper.PadCenter("", ' ', 6) + borde;           
            }
            // Salto de linea para separar las filas
            semana += "\n";
        }
        // Presentar el resultado        
        Console.Write(semana + separadorFilas + "\n");
    }

    private void _Mes(){
        // Calcular el numero de semanas que tendra el mes completas
        int semanas = (cantidadDias + (int) diaInicial) / 7;

        // Agregar una semana adicional si faltan dias para completar el mes
        int semanaAdicional = (cantidadDias + (int) diaInicial) % 7 > 0 ? 1 : 0;

        // Obtener las semanas necesarias para completar el mes
        int numSemanas = semanas + semanaAdicional;

        // Crear la salida a consola de cada semana
        for (int i = 0; i < numSemanas; i++){
            Semana((int) diaInicial, i);
        }
    }

    // Desplegar en consola el calendario generado
    public void PresentarCalendario(){
        Encabezado();
        EncabezadoDias();
        _Mes();
    }
}