int op;
float balance = 500;
int displayStart = 46;
int displayEnd = 84;

List<string> options = new List<string>();
options.Add("***---Sistema Bancario---***");
options.Add("  1 - Checar Saldo");
options.Add("  2 - Depositar");
options.Add("  3 - Sacar");
options.Add("  4 - Sair");


while (true)
{
    Console.Clear();
    buildFrame(0, 0, 91, 21);
    buildFrame(displayStart, 1, displayEnd, 18);
    buildCredits();
    op = buildMenu(options, 3, 1);

    if (op == 1)
    {
       showBalance(balance);
    }
    else if (op == 2)
    {
        balance = makeDeposit(balance);
    }
    else if (op == 3)
    {
        balance = makeWithdraw(balance);
    }
    else if (op == 4)
    {
        Console.Clear();
        Console.WriteLine("Encerrando Programa...");
        Console.Write("Encerrado!");
        break;
    }
    else
    {
        Console.SetCursorPosition(50, 3);
        Console.Write("Inválido! -pressione uma tecla-");
        Console.ReadKey();
    }
    
}

void buildFrame(int cStart, int rStart, int cEnd, int rEnd)
{
    int col, row;
    for (row = rStart; row <= rEnd; row++)
    {
        Console.SetCursorPosition(cStart, row);
        Console.Write("|");
        Console.SetCursorPosition(cEnd, row);
        Console.Write("|");

        for (col = cStart; col <= cEnd; col++)
        {
            Console.SetCursorPosition(col, rStart);
            Console.Write("-");
            Console.SetCursorPosition(col, rEnd);
            Console.Write("-");
        }
    }
}

void buildCredits()
{
    buildFrame(3, 10, 32, 18);
    Console.SetCursorPosition(14, 12);
    Console.Write("ENG SOFT");
    Console.SetCursorPosition(12, 13);
    Console.Write("CATÓLICA-SC");
    Console.SetCursorPosition(10, 15);
    Console.Write("Vinicius Batista");
    Console.SetCursorPosition(32, 20);
    Console.Write("@ovinicius_batista");
}

int buildMenu(List<string> ops ,int col, int row)
{
    int choice, cStart, rStart, cEnd, rEnd;
    cStart = col;
    rStart = row;
    cEnd = col + ops[0].Length + 1;
    rEnd = row + ops.Count + 2;
    if (cEnd - cStart < 28)
        cEnd = cStart + 28;

    buildFrame(cStart, rStart, cEnd, rEnd);
    Console.SetCursorPosition(cStart + 1, rStart + 1);
    int line = rStart + 1;
    for (int i = 0; i < ops.Count; i++)
    {
        Console.SetCursorPosition(cStart + 1, line);
        Console.WriteLine(ops[i]);
        line++;
    }
    Console.SetCursorPosition(cStart + 1, line);
    Console.Write("Número da opção: ");
    choice = int.Parse(Console.ReadLine());

    return choice;
}

void showBalance(float balance)
{
    Console.SetCursorPosition(displayStart + 14, 2);
    Console.WriteLine("==Balanço==");
    Console.SetCursorPosition(displayStart + 10, 8);
    Console.Write("Saldo atual: R$" + balance);
    Console.SetCursorPosition(displayStart + 6, 17);
    Console.Write("Pressione qualquer tecla");
    Console.ReadKey();
}

float makeDeposit(float balance)
{
    float newBalance = 0;
    float depositValue = 0;
    Console.SetCursorPosition(displayStart + 14, 2);
    Console.WriteLine("==Deposito==");
    Console.SetCursorPosition(displayStart + 2, 4);
    while (true)
    {
        Console.Write("Digite o valor p/ deposito:");
        depositValue = float.Parse(Console.ReadLine());
        if (depositValue <= 0)
        {
            Console.SetCursorPosition(displayStart + 1, 6);
            Console.Write("Valor Inválido");
            break;
        }
        else
        {
            Console.SetCursorPosition(displayStart + 5, 8);
            Console.Write($"Depositando R${depositValue}");
            newBalance = balance + depositValue;
            break;
        }
    }

    Console.SetCursorPosition(displayStart + 6, 17);
    Console.Write("Pressione qualquer tecla");
    Console.ReadKey();

    return newBalance;
}

float makeWithdraw(float balance)
{
    float withdrawValue = 0;
    float newBalance = 0;
    Console.SetCursorPosition(displayStart + 14, 2);
    Console.WriteLine("==Sacar==");
    while (true)
    {
        Console.SetCursorPosition(displayStart + 2, 4);
        Console.Write("Digite o valor p/ Sacar:");
        withdrawValue = float.Parse(Console.ReadLine());
        if (withdrawValue <= 0 || withdrawValue > balance)
        {
            Console.SetCursorPosition(displayStart + 1, 6);
            Console.Write("Valor Inválido");
            break;
        }
        else
        {
            Console.SetCursorPosition(displayStart + 5, 8);
            Console.Write($"Sacando R${withdrawValue}");
            newBalance = balance - withdrawValue;
            break;
        }
    }

    Console.SetCursorPosition(displayStart + 6, 17);
    Console.Write("Pressione qualquer tecla");
    Console.ReadKey();
    return newBalance;
}