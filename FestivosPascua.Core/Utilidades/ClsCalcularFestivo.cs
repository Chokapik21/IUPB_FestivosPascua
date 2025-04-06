using FestivosPascua.Dominio.Entidades;

namespace FestivosPascua.Core.Utilidades
{
    public static class ClsCalcularFestivo
    {
        public static List<ClsFestivos> ValidarFechas(int año, ClsTipo tipoSemanaSanta)
        {
            // Cálculo correcto del Domingo de Pascua usando el algoritmo de Meeus
            int a = año % 19;
            int b = año / 100;
            int c = año % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int mes = (h + l - 7 * m + 114) / 31;
            int dia = ((h + l - 7 * m + 114) % 31) + 1;

            DateTime domingoPascua = new DateTime(año, mes, dia);
            DateTime domingoRamos = domingoPascua.AddDays(-7);
            DateTime juevesSanto = domingoPascua.AddDays(-3);
            DateTime viernesSanto = domingoPascua.AddDays(-2);
            DateTime lunesPascua = domingoPascua.AddDays(1);

            // Lista de festivos
            var festivos = new List<ClsFestivos>
        {
            new ClsFestivos
            {
                Nombre = "Domingo de Ramos",
                Dia = domingoRamos.Day,
                Mes = domingoRamos.Month,
                DiasPascuas = -7,
                IdTipo = tipoSemanaSanta.Id,
                Tipo = tipoSemanaSanta
            },
            new ClsFestivos
            {
                Nombre = "Jueves Santo",
                Dia = juevesSanto.Day,
                Mes = juevesSanto.Month,
                DiasPascuas = -3,
                IdTipo = tipoSemanaSanta.Id,
                Tipo = tipoSemanaSanta
            },
            new ClsFestivos
            {
                Nombre = "Viernes Santo",
                Dia = viernesSanto.Day,
                Mes = viernesSanto.Month,
                DiasPascuas = -2,
                IdTipo = tipoSemanaSanta.Id,
                Tipo = tipoSemanaSanta
            },
            new ClsFestivos
            {
                Nombre = "Domingo de Pascua",
                Dia = domingoPascua.Day,
                Mes = domingoPascua.Month,
                DiasPascuas = 0,
                IdTipo = tipoSemanaSanta.Id,
                Tipo = tipoSemanaSanta
            },
            new ClsFestivos
            {
                Nombre = "Lunes de Pascua",
                Dia = lunesPascua.Day,
                Mes = lunesPascua.Month,
                DiasPascuas = 1,
                IdTipo = tipoSemanaSanta.Id,
                Tipo = tipoSemanaSanta
            }
        };

            return festivos;
        }
    }
}
