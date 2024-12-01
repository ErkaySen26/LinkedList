using LinkedList2;
using System;
using System.CodeDom;
using static System.Net.Mime.MediaTypeNames;
//ifadesinde  komut isteminde seçenekli bir şekilde seçenekleri seçmemizi sağlıyor ...
int sayi, indis;
Liste tyList = new Liste();
int secim = Menu();
while (secim != 0)
{
    switch (secim)
    {
        case 1:
            Console.WriteLine("sayı :");
            sayi = int.Parse(Console.ReadLine());
            tyList.basaekle(sayi);
            break;

        case 2:
            Console.WriteLine("Sayı:");
            sayi = int.Parse(Console.ReadLine());
            tyList.sonaekle(sayi);
            break;
        case 3:
            Console.WriteLine("Sayı:");
            indis = int.Parse(Console.ReadLine());
            tyList.ArayaEkle(indis);
            break;

        case 4:
            tyList.bastanSil();
            break;

        case 5:
            tyList.sondanSil();
            break;
        case 6:
            Console.WriteLine("Sayı: "); indis = int.Parse(Console.ReadLine());
            tyList.AradanSil(indis);
            break;
        case 7:

            tyList.ElemanSay();
            break;

        case 0:
            break;
        default:
            Console.WriteLine("Hatalı seçim yaptınız ");
            break;

    }
    Console.Clear();
    tyList.yazdir();
    secim = Menu();
}

int Menu()
{
    int secim;
    Console.WriteLine("\n1 - Listede Başa Eleman Ekleme ");
    Console.WriteLine("2 - Listede Sona Eleman Ekleme ");
    Console.WriteLine("3 - Listede Araya Eleman Ekleme ");
    Console.WriteLine("4 - Listede Baştan Eleman Silme ");
    Console.WriteLine("5 - Listede Sondan Eleman Silme ");
    Console.WriteLine("6 - Listede Aradan Eleman Silme ");
    Console.WriteLine("7 - Listedeki Eleman Sayısı ");
    Console.WriteLine("0 - Programı kapat");
    Console.WriteLine("Lütfen Seçiminizi Yapınız :");
    secim = int.Parse(Console.ReadLine());
    return secim;
}

namespace LinkedList2
{
    class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
    //İfadesi c dilinde düğüm oluşturma kodudur 
    /* main() 
    {
    struct node * head; // henüz bellekte yer kaplamıyor
    head = (struct node *)malloc(sizeof(struct node));
    // artık bellekte yer tahsis edilmiştir.
    head -> data = 1;
    head -> next = NULL;



    listeye yeni eleman ekleme 
    C++'ta head -> next = new node() şeklinde kullanılabilir. 
    head -> next = (struct node *)malloc(sizeof(struct node));
    head -> next -> data = 3;
    head -> next -> next = NULL;  */

    class Liste
    {
        Node head;

        public Liste()
        {
            head = null;
        }
        public void basaekle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = eleman;
                Console.WriteLine("Liste oluşturuldu, ilk eleman eklendi");
            }
            else
            {
                eleman.next = head;
                head = eleman;
                Console.WriteLine("Başa eleman eklendi");
            }
        }
        //İfadesi c dilinde başa ekleme 
        // Tek bağlı doğrusal listenin başına eleman eklemek
        // struct node *addhead(struct node *head,int key) {
        //struct node *temp = (struct node *)malloc(sizeof(struct node));
        //temp -> data = key;
        //temp -> next = head; // temp’in next’i şu anda head’i gösteriyor.
        ///* Bazen önce listenin boş olup olmadığı kontrol edilir, ama gerekli değil aslında.
        //Çünkü boş ise zaten head=NULL olacaktır ve temp olan ilk düğümün next’i NULL gösterecektir. */
        //head = temp; /* head artık temp’in adresini tutuyor yani eklenen düğüm listenin başı oldu. */
        //return head;
        //}
        public void sonaekle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = eleman;
                Console.WriteLine("Liste oluşturuldu, ilk eleman eklendi");
            }
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = eleman;
                Console.WriteLine("Sona eleman eklendi");
            }
        }
        //ifadesi c dilin için sonaekleme kodudur
        //struct node *addlast(struct node *head,int key) {
        //struct node *temp = (struct node *)malloc(sizeof(struct node));
        ///* C++'ta struct node *temp = new node(); * şeklinde kullanılabileceğini unutmayınız. */
        //temp -> data = key;
        //temp -> next = NULL;
        //struct node *temp2 = head;
        ///* Aşağıdaki while yapısı traversal(dolaşma) olarak adlandırılır */
        //while(temp2 -> next != NULL)
        //temp2 = temp2 -> next;
        //temp2 -> next = temp;
        //return head;
        //}

        //...

        public void ArayaEkle(int sayi)
        {
            Node eleman = new Node(sayi);

            if (head == null)
            {
                head = eleman;
                Console.WriteLine("Liste oluşturuldu, ilk eleman eklendi");
            }
            else if (head.next == null)
            {
                // Liste sadece bir eleman içeriyor, bu durumda yeni elemanı ekleyebiliriz.
                eleman.next = head.next;
                head.next = eleman;
                Console.WriteLine("Araya eklendi");
            }
            else
            {
                // Liste üzerinde iki veya daha fazla eleman varsa, yeni elemanı listenin ortasına ekleyebiliriz.
                Node slow = head;
                Node fast = head;

                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }

                eleman.next = slow.next;
                slow.next = eleman;

                Console.WriteLine("Araya eklendi");
            }
        }
        public void bastanSil() //?//
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else
            {
                head = head.next;
                Console.WriteLine("Baştan eleman silindi");
            }
        }

        public void sondanSil() //??//
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else if (head.next == null)
            {
                head = null;
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                while (temp.next != null)
                {
                    temp2 = temp;
                    temp = temp.next;
                }
                temp2.next = null;
                Console.WriteLine("Sondan eleman silindi");
            }
        }
        public void AradanSil(int sayi)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else if (head.next == null)
            {
                if (head.data == sayi)
                {
                    head = null;
                    Console.WriteLine("Listede kalan son elemanı da sildiniz");
                }
                else
                {
                    Console.WriteLine("Listede silmek istediğiniz eleman bulunamadı");
                }
            }
            else if (head.data == sayi)
            {
                bastanSil();
                Console.WriteLine("Eleman silindi");
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;

                while (temp.next != null)
                {
                    if (temp.data == sayi)
                    {
                        temp2.next = temp.next;
                        Console.WriteLine("Aradan eleman silindi");
                        return;
                    }
                    temp2 = temp;
                    temp = temp.next;
                }

                if (temp.data == sayi)
                {
                    sondanSil();
                    temp2.next = null;
                    Console.WriteLine("Aradan eleman silindi");
                }
                else
                {
                    Console.WriteLine("Listede silmek istediğiniz eleman bulunamadı");
                }
            }
        }

        //ifadesi c dilinde verilen bir değere sahip düğümü silmek
        //struct node *remove(struct node *head, int key) {
        //if(head == NULL) {
        //printf("Listede eleman yok\n");
        //return;
        //}
        //struct node * temp = head;
        //if(head -> data == key) { // ilk düğüm silinecek mi diye kontrol ediliyor.
        //head = head -> next; // head artık bir sonraki eleman.
        //free(temp);
        //}
        //else if (temp->next == NULL)
        //{ // Listede tek düğüm bulunabilir.
        //printf("Silmek istediginiz veri bulunmamaktadir.\n\n");
        //  return head;
        //}
        //else
        //{
        //while (temp->next->data != key)
        //{
        //         if (temp->next->next == NULL)
        //        {
        //            printf("Silmek istediginiz veri bulunmamaktadir.\n\n");
        //            return head;
        //        }
        //        temp = temp->next;
        //    }
        //struct node *temp2 = temp->next;
        //temp -> next = temp -> next -> next;
        //free(temp2);
        //}
        //return head;
        //}

        public void ElemanSay()
        {
            int sayac = 0;

            Node temp = head;
            while (temp != null)
            {
                sayac++;
                temp = temp.next;
            }

            Console.WriteLine("Eleman sayısı: " + sayac);
            Console.ReadKey();
        }



        //int count(struct node *head) {
        //int counter = 0;
        //while(head != NULL) { // head->next!=NULL koşulu olsaydı son düğüm sayılmazdı
        //counter++;
        //head = head -> next;
        //}
        //return counter;
        //}

        public void yazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş");
            }
            else
            {
                Node temp = head;
                Console.Write("Baş -> ");
                while (temp.next != null)
                {
                    Console.Write(temp.data + " -> ");
                    temp = temp.next;
                }
                Console.WriteLine(temp.data + " -> Son.");
            }
            //void print(struct node *head) {
            //if(head == NULL) {
            //printf("Listede eleman yok");
            //return;
            //}
            //struct node * temp2 = head;
            //while(temp2!= NULL) { // temp2->next!=NULL koşulu olsaydı son düğüm yazılmazdı
            //printf("%d\n", temp2 -> data);
            //temp2 = temp2 -> next;
            //}
            //}
        }


    }
}