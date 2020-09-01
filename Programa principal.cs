using System;
using System.Diagnostics; // Contagem de tempo de execução dos métodos
using std_alex; // Insere as classes criadas no arquivo Classes.cs

class Program
{
    static void Main(string[] args) // Cria o array a ser ordenado, faz a chamada do método de ordenação e mede o tempo de cada execução
    {   

        // Cria os objetos das classes Criar, Print, Sorting e Stopwatch
        Criar v_criar = new Criar();
        Print v_print = new Print();
        Sorting v_ordena = new Sorting();
        Stopwatch tempo = new Stopwatch();

        int tipo_alg = 0;
        long trocas, tamanho;

        tamanho = 10;
        
        //int[] temp = new int[tamanho];

        do
        {
            int[] vetor = new int[tamanho];
            int[] vetor_original = new int[tamanho];

            v_criar.ArrayInvertido(ref vetor); // Fornece números ao vetor, que é passado por referência
            vetor.CopyTo(vetor_original, 0);

            trocas = 0;

            tempo.Restart(); // Inicia contagem do tempo
            trocas = v_ordena.bubbleSort(ref vetor);    // BubbleSort
            tempo.Stop(); // Para a contagem de tempo
            tipo_alg++;
            Console.Write("\nAlgoritmo: " + tipo_alg + "\nTamanho do vetor: " + tamanho + "\nNúmero de trocas: " + trocas + "\nTempo de execução: " + tempo.Elapsed + "\n\n");
            //v_print.printa(vetor);
            vetor_original.CopyTo(vetor, 0);
            trocas = 0;

            tempo.Restart(); // Inicia contagem do tempo
            trocas = v_ordena.insertionSort(ref vetor);  // InsertionSort
            tempo.Stop(); // Para a contagem de tempo
            tipo_alg++;
            Console.Write("\nAlgoritmo: " + tipo_alg + "\nTamanho do vetor: " + tamanho + "\nNúmero de trocas: " + trocas + "\nTempo de execução: " + tempo.Elapsed + "\n\n");
            //v_print.printa(vetor);
            vetor_original.CopyTo(vetor, 0);
            trocas = 0;

            tempo.Restart(); // Inicia contagem do tempo
            trocas = v_ordena.binaryInsertionSort(ref vetor);   // BinaryInsertionSort
            tempo.Stop(); // Para a contagem de tempo
            tipo_alg++;
            Console.Write("\nAlgoritmo: " + tipo_alg + "\nTamanho do vetor: " + tamanho + "\nNúmero de trocas: " + trocas + "\nTempo de execução: " + tempo.Elapsed + "\n\n");
            //v_print.printa(vetor);
            vetor_original.CopyTo(vetor, 0);
            trocas = 0;

            tempo.Restart(); // Inicia contagem do tempo
            trocas = v_ordena.shellSort(ref vetor, Convert.ToInt32(tamanho) , tipo_alg-2);    // ShellSort com sequencia Shell
            tempo.Stop(); // Para a contagem de tempo
            tipo_alg++;
            Console.Write("\nAlgoritmo: " + tipo_alg + "\nTamanho do vetor: " + tamanho + "\nNúmero de trocas: " + trocas + "\nTempo de execução: " + tempo.Elapsed + "\n\n");
            //v_print.printa(vetor);
            vetor_original.CopyTo(vetor, 0);
            trocas = 0;

            tempo.Restart(); // Inicia contagem do tempo
            trocas = v_ordena.shellSort(ref vetor, Convert.ToInt32(tamanho), tipo_alg-2); //ShellSort com sequencia Knuth
            tempo.Stop(); // Para a contagem de tempo
            tipo_alg++;
            Console.Write("\nAlgoritmo: " + tipo_alg + "\nTamanho do vetor: " + tamanho + "\nNúmero de trocas: " + trocas + "\nTempo de execução: " + tempo.Elapsed + "\n\n");
            //v_print.printa(vetor);
            vetor_original.CopyTo(vetor, 0);
            trocas = 0;

            tempo.Restart(); // Inicia contagem do tempo
            trocas = v_ordena.shellSort(ref vetor, Convert.ToInt32(tamanho), tipo_alg-2);    //ShellSort com sequencia Tokuda
            tempo.Stop(); // Para a contagem de tempo
            tipo_alg++;
            Console.Write("\nAlgoritmo: " + tipo_alg + "\nTamanho do vetor: " + tamanho + "\nNúmero de trocas: " + trocas + "\nTempo de execução: " + tempo.Elapsed + "\n\n");
            //v_print.printa(vetor);
            vetor_original.CopyTo(vetor, 0);
            trocas = 0;

            tamanho *= 10;  
            tipo_alg = 0;
        } while (tamanho <= 100); // Mudar tamanho do vetor
        Console.Write("\n\n\nFim");
        Console.ReadKey();

        /*   
        // Determina o tamanho do vetor, o cria e atribui elementos aleatórios, ordenados ou invertidos
        Console.Write("Tamanho do array: ");
        tamanho = Convert.ToUInt64(Console.ReadLine());

        Console.Write("\nSelecione:\n1 - Criar array aleatório\n2 - Criar array ordenado\n3 - Criar array invertido\n");
        n = Convert.ToInt32(Console.ReadLine());

        switch (n)
        {
            case 1: v_criar.ArrayAleatorio(ref vetor); break; // Fornece números aleatórios ao vetor, que é passado por referência
            case 2: v_criar.ArrayOrdenado(ref vetor); break;
            case 3: v_criar.ArrayInvertido(ref vetor); break;
            default: v_criar.ArrayAleatorio(ref vetor); break;
        }

        v_print.printa(vetor); // Printa o vetor criado
        

        v_criar.ArrayAleatorio(ref vetor); // Fornece números aleatórios ao vetor, que é passado por referência
        v_criar.ArrayOrdenado(ref vetor);
        v_criar.ArrayInvertido(ref vetor);

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        // Escolhe o algoritmo de ordenação que será utilizado, inicia a contagem de tempo e chama os respectivos métodos

        /*
        Console.Write("\nSelecione:\n1 - Bubble Sort\n2 - Insertion Sort\n3 - Binary Insertion Sort\n4 - Shell Sort\n");
        n = Convert.ToInt32(Console.ReadLine());

        trocas = 0;

        tempo.Reset();
        tempo.Start(); // Inicia contagem do tempo

        switch (n)
        {
            case 1: trocas = v_ordena.bubbleSort(ref vetor); break;
            case 2: trocas = v_ordena.insertionSort(ref vetor); break;
            case 3: trocas = v_ordena.binaryInsertionSort(ref vetor); break;
            case 4:
                Console.Write("\nNúmero máximo de elementos na sequência: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSelecione:\n1 - Sequência Shell\n2 - Sequência Knuth\n3 - Sequência Tokuda\n");
                s = Convert.ToInt32(Console.ReadLine());
                tempo.Restart(); // Zera timer e reinicia contagem do tempo
                trocas = v_ordena.shellSort(ref vetor, n, s);
                break;
            default: Console.Write("\nInválido\n"); break;
        }
        

        s = 1; // Seleciona qual sequência será usada no ShellSort
        trocas = 0;
        tempo.Reset();
        tempo.Start(); // Inicia contagem do tempo

        trocas = v_ordena.bubbleSort(ref vetor);
        trocas = v_ordena.insertionSort(ref vetor);
        trocas = v_ordena.binaryInsertionSort(ref vetor);
        trocas = v_ordena.shellSort(ref vetor, n, s);

        tempo.Stop(); // Para a contagem de tempo

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        // Printa o vetor ordenado, o número de trocas necessárias para ordenar o vetor e o tempo de execução do método de ordenação
        //v_print.printa(vetor);

        /*Console.Write("\nNúmero de trocas: " + trocas + "\nTempo de execução: " + tempo.Elapsed + "\n\n");
        
        Console.ReadKey();
        */
    }
}
