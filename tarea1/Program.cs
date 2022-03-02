Console.WriteLine("\t\tBienvenido, al menu de opciones.\n");
Console.WriteLine("1. Convertir de Fahrenheit a Celcius");
Console.WriteLine("2. Convertir de Celcius a Fahrenheit");
Console.WriteLine("3. Calculadora");
Console.Write("\nQue desea realizar: ");

int opt = 0;
string? str = Console.ReadLine();

if (string.IsNullOrEmpty(str))
{
    Environment.Exit(0);
}
else
{
    opt = int.Parse(str);
}

switch (opt)
{
    case 1:
        Fahrenheit();
        break;
    case 2:
        Celsius();
        break;
    case 3:
        Calculadora();
        break;
    default:
        Environment.Exit(0);
        break;
}


static void Fahrenheit()
{
    Console.Write("Ingrese la cantidad a convertir: ");

    int num = 0;
    string? str = Console.ReadLine();
    if (string.IsNullOrEmpty(str))
    {
        Environment.Exit(0);
    }
    else
    {
        num = int.Parse(str);
    }

    float res = ((num - 32) * 5 ) / 9;
    Console.WriteLine("Resultado: {0}", res);
}

static void Celsius()
{
    Console.Write("Ingrese la cantidad a convertir: ");

    int num = 0;
    string? str = Console.ReadLine();
    if (string.IsNullOrEmpty(str))
    {
        Environment.Exit(0);
    }
    else
    {
        num = int.Parse(str);
    }

    float res = ((num * 9) / 5) + 32;
    Console.WriteLine("Resultado: {0}", res);
}

static void Calculadora()
{
    Console.Clear();
    Console.WriteLine("1. Sumar");
    Console.WriteLine("2. Restar");
    Console.WriteLine("3. Multiplicar");
    Console.WriteLine("4. Dividir");

    int calOpt = 0;
    string? str = Console.ReadLine();

    if (string.IsNullOrEmpty(str))
    {
        Environment.Exit(0);
    }
    else
    {
        calOpt = int.Parse(str);
    }

    int num1 = 0, num2 = 0;
    int res = 0;

    Console.WriteLine("Ingrese el primer valor: ");
    string? strnum1 = Console.ReadLine();
    if (string.IsNullOrEmpty(strnum1))
    {
        Environment.Exit(0);
    }
    else
    {
        num1 = int.Parse(strnum1);
    }

    Console.WriteLine("Ingrese el segundo valor: ");
    string? strnum2 = Console.ReadLine();
    if (string.IsNullOrEmpty(strnum2))
    {
        Environment.Exit(0);
    }
    else
    {
        num2 = int.Parse(strnum2);
    }


    switch (calOpt)
    {
        case 1:
            res = Sum(num1, num2);
            break;
        case 2:
            res = Restar(num1, num2);
            break;
        case 3:
            res = Multiplicar(num1, num2);
            break;
        case 4:
            res = Dividir(num1, num2);
            break;
        default:
            Environment.Exit(0);
            break;
    }

    Console.WriteLine("El resultado es: {0}", res);
}

static int Sum(int num1, int num2)
{
    return num1 + num2;
}

static int Restar(int num1, int num2)
{
    return num1 - num2;
}

static int Multiplicar(int num1, int num2)
{
    return num1 * num2;
}

static int Dividir(int num1, int num2)
{
    return num1 / num2;
}
