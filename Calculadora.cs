namespace EspacioCalculadora;

public class Empleado
{
    public string Nombre{get; set;}
    public string Apellido{get; set;}
    public DateTime fechaNacimiento{get; set;}
    public DateTime fechaIngreso{get; set;}
    public char estadoCivil{get; set;}
    public char genero{get; set;}
    public double sueldoBasico{get; set;}
    public Cargos Cargo{get; set;}

    public enum Cargos
    {
        Auxiliar,
        Administrativo,
        Ingeniero,
        Especialista,
        Investigador
    }

    public int CalcularAntiguedad()
    {
        DateTime fechaActual = DateTime.Now;
        TimeSpan diferencia = fechaActual - FechaIngreso;
        int antiguedad = (int)(diferencia.TotalDays / 365.25);
        return antiguedad;
    }

    public int calcularEdad()
    {
        DateTime fechaActual = DateTime.Now;
        TimeSpan diferencia = fechaActual - fechaNacimiento;
        int edad = (int)(diferencia.TotalDays/365.25);
        return edad;
    }

    public int jubilacion()
    {
        if (genero == "m")
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan diferencia = fechaActual - fechaNacimiento;
            int edad = (int)(diferencia.TotalDays/365.25);
            int jubilacion = 65-edad;
            return jubilacion;
        }else if (genero == "f")
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan diferencia = fechaActual - fechaNacimiento;
            int edad = (int)(diferencia.TotalDays/365.25);
            int jubilacion = 60-edad;
            return jubilacion;
        }


    }
    public double CalcularSalario()
    {
        int antiguedad = CalcularAntiguedad();
        double adicional = 0;

        if (antiguedad <= 20)
        {
            adicional = SueldoBasico * (antiguedad * 0.01);
        }
        else
        {
            adicional = SueldoBasico * 0.25;
        }

        if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
        {
            adicional *= 1.5;
        }

        if (EstadoCivil == 'C')
        {
            adicional += 15000;
        }

        double salario = SueldoBasico + adicional;
        return salario;
    }
}  

