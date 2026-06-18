using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Quantos alunos tem na sala?");
        int n = int.Parse(Console.ReadLine());
        
        Aluno[] alunos = new Aluno[n];
        int tamanhoLogico = 0;
        int opcao = -1;
        
        while (opcao != 0)
        {
            Console.WriteLine("\n======= MENU =========");
            Console.WriteLine("0 - sair do programa");
            Console.WriteLine("1 - cadastrar aluno");
            Console.WriteLine("2 - listar todos os alunos");
            Console.Write("Escreva sua opçao: ");
            
            if (int.TryParse(Console.ReadLine(), out opcao)) // Mudado para TryParse para evitar erros se o usuário digitar letras
            {
                switch (opcao)
                {
                    case 1:
                        if (tamanhoLogico < alunos.Length)
                        {
                            Console.WriteLine("\n======== CADASTRANDO ALUNO =======");
                            alunos[tamanhoLogico] = new Aluno();
                            alunos[tamanhoLogico].leiaAluno();
                            tamanhoLogico++;
                            Console.WriteLine("ALUNO CADASTRADO COM SUCESSO!");
                        }
                        else
                        {
                            Console.WriteLine("Limite de alunos atingido!");
                        }
                        break;
                        
                    case 2:
                        Console.WriteLine("\n========= LISTA DE ALUNOS =======");
                        if (tamanhoLogico == 0)
                        {
                            Console.WriteLine("Nenhum aluno cadastrado ainda.");
                        }
                        else
                        {
                            for (int i = 0; i < tamanhoLogico; i++)
                            {
                                Console.WriteLine($"\n--- Aluno {i + 1} ---");
                                alunos[i].escrevaAluno();
                            }
                        }
                        break;
                        
                    case 0:
                        Console.WriteLine("Saindo do Programa...");
                        break;
                        
                    default:
                        Console.WriteLine("Resposta Errada! Tente Novamente");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Digite uma opçao válida!");
            }
        }
    }
}

class Aluno
{
    private string nome;
    private double nota; // Adicionado conforme o PDF
    private Data nascimento = new Data();
    private Data cadastro = new Data(); // Adicionado conforme o PDF

    public void setNome(string nome)
    {
        this.nome = nome;
    }

    public void setNota(double nota)
    {
        if(nota >= 0 && nota <= 100) // Domínio 0..100 conforme o PDF
        {
            this.nota = nota;
        }
    }

    // Corrigido para receber inteiros, conforme diagrama UML
    public bool setNascimento(int dia, int mes, int ano) 
    {
        return this.nascimento.setData(dia, mes, ano);
    }

    // Adicionado para a data de cadastro
    public bool setCadastro(int dia, int mes, int ano)
    {
        return this.cadastro.setData(dia, mes, ano);
    }

    public void leiaNome() // Corrigido de string para void, pois o diagrama pede só leiaNome()
    {
        Console.Write("Qual o nome do aluno? ");
        this.nome = Console.ReadLine();
    }

    public void escrevaNome()
    {
        Console.WriteLine("Nome: " + nome);
    }

    public void leiaAluno()
    {
        this.leiaNome();
        
        Console.Write("Qual a nota do aluno (0 a 100)? ");
        this.setNota(double.Parse(Console.ReadLine()));

        Console.WriteLine("- Data de Nascimento -");
        this.nascimento.leiaData();
        
        Console.WriteLine("- Data de Cadastro -");
        this.cadastro.leiaData();
    }

    public void escrevaAluno()
    {
        this.escrevaNome(); 
        Console.WriteLine("Nota: " + this.nota);
        
        Console.Write("Data de nascimento: ");
        this.nascimento.escrevaData(); 
        
        Console.Write("Data de cadastro: ");
        this.cadastro.escrevaData();
    }

    public Data getNascimento() 
    {
        return this.nascimento;
    }

    public string getNome() 
    {
        return this.nome;
    }
}

class Data
{
    private int dia;
    private int mes;
    private int ano;

    public bool setDia(int dia)
    {
        bool diaAceito = false;
        if (dia > 0 && dia <= 31)
        {
            this.dia = dia;
            diaAceito = true;
        }
        return diaAceito;
    }

    public bool setMes(int mes)
    {
        bool mesAceito = false;
        if (mes > 0 && mes <= 12)
        {
            this.mes = mes;
            mesAceito = true;
        }
        return mesAceito;
    }

    public void setAno(int ano)
    {
        this.ano = ano;
    }

    public bool dataValida(int dia, int mes, int ano)
    {
        bool valido = true;
        if (mes < 1 || mes > 12 || dia < 1 || dia > diasMes(mes, ano))
        {
            valido = false;
        }
        return valido;
    }

    public int diasMes(int mes, int ano)
    {
        switch (mes)
        {
            case 4: case 6: case 9: case 11:
                return 30;
            case 2:
                
                if (ano % 4 == 0)
                {
                    return 29;
                }
                else 
                { 
                    return 28; 
                }
            default: 
                return 31;
        }
    }

    public string mesExtenso()
    {
        switch (this.mes)
        {
            case 1: return "janeiro";
            case 2: return "fevereiro";
            case 3: return "março";
            case 4: return "abril";
            case 5: return "maio";
            case 6: return "junho";
            case 7: return "julho";
            case 8: return "agosto";
            case 9: return "setembro";
            case 10: return "outubro";
            case 11: return "novembro";
            case 12: return "dezembro";
            default: return "mes invalido"; 
        }
    }

    public bool setData(int dia, int mes, int ano)
    {
        bool dataAceita = false;
        if (dataValida(dia, mes, ano))
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            dataAceita = true;
        }
        return dataAceita;
    }

    public int getDia() 
    {  
        return dia;
    }

    public int getMes() 
    {
        return mes;
    }

    public int getAno() 
    {
        return ano;
    }

    public void leiaData()
    {
        Console.Write("Dia: ");
        int dia = int.Parse(Console.ReadLine());
        Console.Write("Mês: ");
        int mes = int.Parse(Console.ReadLine());
        Console.Write("Ano: ");
        int ano = int.Parse(Console.ReadLine());

        if (this.setData(dia, mes, ano) == false)
        {
            Console.WriteLine("Data Inválida! Cadastrada como 0/0/0.");
        }
    }

    public void escrevaData()
    {
        Console.WriteLine(this.dia + " de " + this.mesExtenso() + " de " + this.ano);
    }
}