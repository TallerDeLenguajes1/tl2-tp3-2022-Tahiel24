using System;
using System.Collections.Generic;
namespace TP3{
    class Program{
        static void Main(string[]args){
            List<Cadete>ListadoCadetes=new List<Cadete>();
            List<Cliente>ListadoClientesN=new List<Cliente>();
            List<Pedido>ListadoPedidosN=new List<Pedido>();
            string[]lineas=File.ReadAllLines(@"C:\TALLER 2\REPOS\Interfaz de empleados\Cadetes.csv");
            List<string>contenido=new List<string>();
            int cantPedidos,cont=1;
            foreach(var i in lineas)
            {
                string[]fila=i.Split(",");
                int num = Convert.ToInt32(fila[0]);
                Cadete nuevoCadete=new Cadete(num, fila[1], fila[2], fila[3]);
                ListadoCadetes.Add(nuevoCadete);
            }

            Cadeteria nuevaCadeteria=new Cadeteria(ListadoCadetes);
            
            Console.WriteLine("-----------------------INTERFAZ DE LA CADETERIA------------------------");
            Console.WriteLine("1_Dar de alta pedidos ");
            Console.WriteLine("2_Asignarlos a cadetes ");
            Console.WriteLine("3_Cambiar de estado el pedido");
            Console.WriteLine("4_Cambiar pedidos de cadetes");
            Console.Write("Opcion: );
            /*Console.WriteLine("5_ Dar por finalizado el dia");*/
            int opcion;
            do
            {
                opcion=Convert.ToInt32(Console.ReadLine());
            }while(opcion<1&&opcion>4)
            Console.WriteLine("\n");
            while (opcion != 5)
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("|||Dar de alta pedidos|||");
                        Console.Write("Ingrese la cantidad de pedidos a agregar al sistema: ");
                        cantPedidos=Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < cantPedidos; i++)
            			{
                            Cliente nuevoCliente=new Cliente();
                            ListadoClientesN.Add(nuevoCliente);
                            Pedido nuevoPedido=new Pedido(nuevoCliente.Nombre,nuevoCliente.Direccion);
                            ListadoPedidosN(nuevoPedido);
            			}
                        Console.WriteLine("Pedidos subidos al sistema con exito");
                        break;
                    case 2:
                        Console.WriteLine("|||Asignar pedidos a cadetes|||");
                        int numPedido,cade,op1;
                        if (ListadoPedidosN.Any())
                        {
                            Console.WriteLine("Lista de pedidos y cadetes: ");
                            foreach(var i in ListadoPedidosN)
                            {
                                Console.WriteLine("Cliente: "+i.Cliente+"-"+" Direccion: "+i.Dir+"- Numero de pedido: "+i.Nro);
                            }
                            Console.WriteLine("/n");
                            foreach(var i in ListadoCadetes)
                            {
                                Console.WriteLine(cont+"_ "+"ID del cadete: "+i.Id);
                                cont++;
                            }

                            while (op1 != 2)
                            {
                                Console.WriteLine("Seleccione el nro de pedido e id cadete a asignar:");
                                Console.Write("Pedido: ");
                                numPedido=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("/n");
                                Console.WriteLine("Cadete: ");
                                cade=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("/n");
                                Console.WriteLine("Desea agregar mas pedidos o salir?(1:salir, 2:seguir ");
                                do
                                {
                                    op1=Convert.ToInt32(Console.ReadLine());
                                }while(op1<1&&op1>2);
                            }
                            Console.WriteLine("Pedidos movidos con exito");
                        }
                        else
                        {
                            Console.WriteLine("La lista de pedidos esta vacia, ingrese pedidos al sistema primero(Opcion 1)");
                            break;
                        }
                }
            }
            
            

            /*for (int i = 0; i < 10; i++)
            {
                Cadete nuevoCadete=new Cadete();
                ListadoCadetes.Add(nuevoCadete);
            }
            List<string>cadena=new List<string>();
            foreach(var i in ListadoCadetes){
                cadena.Add(i.Id+","+i.Nombre+","+i.Direccion+","+i.Telefono1);
            }
            string path=@"C:\TALLER 2\REPOS\Interfaz de empleados\Cadetes.csv";
            File.WriteAllLines(path,cadena);*/
        }
    }
}
