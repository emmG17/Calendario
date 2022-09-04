class StringHelper {
    // Centrar el texto entre una cantidad arbitraria de caracteres (separador)
    public static string PadCenter(string texto, char separador, int longitud){
        int espacios = longitud - texto.Length;
        int mitadIzq = espacios/2 + texto.Length;
        return texto.PadLeft(mitadIzq, separador).PadRight(longitud, separador);
    }
}