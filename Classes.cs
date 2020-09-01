using System;
namespace std_alex
{
    public class Criar // Classe que possui os métodos necessários para preencher os vetores aleatoriamente, ordenadamente ou inversamente
    {

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void ArrayAleatorio(ref int[] v)
        {
            Random rnd = new Random(); // Cria objeto da classe Random para criar números aleatórios

            int i;
            int size = v.Length;
            for (i = 0; i < size; i++)
            {
                v[i] = rnd.Next(0, size); // Fornece um número aleatório entre 1 e o tamanho do vetor ao elemento i do vetor;
            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void ArrayOrdenado(ref int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = i;
            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public void ArrayInvertido(ref int[] v_temp)
        {
            int i, j;
            for (i = 0, j = v_temp.Length, j--; j >= 0; i++, j--)
            {
                v_temp[i] = j;
            }
        }
    }

    /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

    public class Print // Classe com um só método usado para printar um vetor
    {
        public void printa(int[] v)
        {
            Console.Write("\nInício -> | ");
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + " | ");
            }
            Console.Write("<- FIM\n"); 
        }
    }

    /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

    public class Sorting : Print // Classe onde estão os métodos de ordenação e os auxiliares e herda a classe Print para poder printar vetores
    {

        long trocas;

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public long bubbleSort(ref int[] v) // Ordena o vetor invertendo pares de trás pra frente, onde o maior sempre vai pra 'direita'
        {
            int m = v.Length - 1, k = 0, temp;
            bool troca;
            trocas = 0;

            do
            {
                troca = false;
                for (int i = 0; i < m; i++) // Percorre o vetor até a posição da última troca (ou até o fim, na primeira varredura)
                {
                    if (v[i] > v[i + 1]) // Se, em um par, o elemento da 'esquerda' for maior que o da 'direita', inverte
                    {
                        temp = v[i];
                        v[i] = v[i + 1];
                        v[i + 1] = temp;

                        k = i; // Posição da troca
                        troca = true;
                        trocas++;
                    }
                }
                m = k; // Posição da última troca
            } while (troca);

            return trocas;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public long insertionSort(ref int[] v) // Ordena o vetor inserindo os elementos (aqui chamarei de cartas, em alusão a um baralho) movendo os elementos menores para o início do vetor
        {
            int carta, i;
            trocas = 0;

            for (int j = 1; j < v.Length; j++)
            {
                carta = v[j]; // A carta é o segundo elemento da varredura
                i = j - 1; // Índice anterior ao da carta (o primeiro da varredura)

                while ((i >= 0) && (v[i] > carta)) // Enquanto o elemento i for maior que a carta, a carta vai 'andando' para trás
                {
                    v[i + 1] = v[i]; // Avança o elemento i uma posição (a posição da carta) (1)
                    i--; trocas++; // i é decrementado para a carta ir uma posição para trás
                }
                v[i + 1] = carta; // Se i não foi decrementado, a carta vai para a posição j (pois i = j - 1), ou seja, anda uma posição pra 'frente'
            }

            return trocas;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public int buscaBinaria(int[] v, int inf, int sup, int key) // Método auxiliar de busca binária
        {
            int half;
            if (inf == sup) //Se os limites são iguais, retorna o limite inferior (para manter a estabilidade do vetor)
                return inf;
            half = inf + ((sup - inf) / 2);
            if (key > v[half]) // Se a chave for maior do que o meio do vetor, chama novamente a função, agora definindo half + 1 como limite inferior
                return buscaBinaria(v, half + 1, sup, key);
            else if (key < v[half]) // Se a chave for menor do que o meio do vetor, chama novamente a função, agora definindo half como limite superior
                return buscaBinaria(v, inf, half, key);
            return half;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public long binaryInsertionSort(ref int[] v) // Ordena o vetor inserindo as cartas nas posições corretas através de busca binária
        {
            int carta, local, m;
            trocas = 0;

            if (v[0] > v[1]) // Ordena os dois primeiros elementos
            {
                int temp = v[0];
                v[0] = v[1];
                v[1] = temp;
                trocas++;
            } 

            for (int e = 2; e < v.Length; e++) //Percorre o vetor
            {
                carta = v[e]; // Seleciona a carta da posição e
                if(carta < v[e-1]) //Como o início do vetor já está ordenado, se a carta for menor ela precisa ser inserida
                {
                    local = buscaBinaria(v, 0, e-1, carta); // Busca qual posição a carta precisa ser inserida

                    for (m = e; m > local; m--) // 'Empurra' os elementos entre a antiga e nova posição da carta para a 'direita'
                    {
                        if(m > 0) v[m] = v[m-1];
                        trocas++;
                    }
                    v[local] = carta; // Adiciona a carta no vetor já ordenado
                }    
            }
            return trocas;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        long insertionShellSort(ref int[] v, int h, int f) // Ordena os segmentos do Shell Sort (usando Insertion Sort com passo 'h')
        {
            long trocas_temp = 0;

            int carta, i;

            for (int j = (f+h); j < v.Length; j+=h) // Percorre o vetor pulando 'h' elementos
            {
                carta = v[j]; 
                i = j - h; 

                while ((i >= 0) && (v[i] > carta)) // Enquanto o elemento i for maior que a carta, a carta vai 'andando' para trás
                {
                    v[i + h] = v[i]; // Avança o elemento i 'h' posições
                    i-=h; trocas_temp++;
                }
                v[i + h] = carta; // Se i não foi decrementado, a carta vai para a posição j (pois i = j - h)
            }

            return trocas_temp;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        public long shellSort(ref int[] v, int n, int tipoSequencia) // Ordena o vetor o divindo em segmentos e ordenando cada segmento, diminuindo o tamanho destes
        {
            trocas = 0;

            int[] sequence = generateGapSequence(n, tipoSequencia);
            int numElems = sequence.Length;
            
            Console.Write("Sequência: "); printa(sequence);
            
            int i, h, f;

            for (i = numElems - 1; i >= 0; i--)
            {
                h = sequence[i];
                for (f = 0; f < h; f++)
                {
                    trocas += insertionShellSort(ref v, h, f);
                }
            }

            return trocas;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

        int[] generateGapSequence(int maxElem, int tipoSequencia) // Gera um vetor com a sequência que será utilizada para dividir e ordenar o vetor no Shell Sort
        {
            int[] seq = null;

            int i, e = 1, numElems = 1;
            if (tipoSequencia == 1)
            {
                /* (Shell,1959) - sequencia 1, 2, 4, 8, 16, 32, ...*/
                while (e < maxElem)
                {
                    e *= 2;
                    numElems++;
                }
                numElems--;
                seq = new int[numElems];
                e = 1;
                for (i = 0; i < numElems; i++)
                {
                    seq[i] = e;
                    e *= 2;
                }
            }
            else if (tipoSequencia == 2)
            {
                /* (Knuth,1971) - sequencia 1, 4, 13, 40, 121, 364, ...*/
                while (e < maxElem)
                {
                    e = e * 3 + 1;
                    numElems++;
                }
                numElems--;
                seq = new int[numElems];
                e = 1;
                for (i = 0; i < numElems; i++)
                {
                    seq[i] = e;
                    e = e * 3 + 1;
                }
            }
            else if (tipoSequencia == 3)
            {
                /* (Tokuda,1992) - sequencia 1, 4, 9, 20, 46, 103, ...*/
                numElems = 0;
                while (e < maxElem)
                {
                    e = Convert.ToInt32(Math.Ceiling((9.0 * Math.Pow(9.0, numElems) / Math.Pow(4.0, numElems) - 4.0) / 5.0));
                    numElems++;
                }
                numElems--;
                seq = new int[numElems];
                for (i = 0; i < numElems; i++)
                {
                    e = Convert.ToInt32(Math.Ceiling((9.0 * Math.Pow(9.0, i) / Math.Pow(4.0, i) - 4.0) / 5.0));
                    seq[i] = e;
                }
            }
            return seq;
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------ */

    }

}