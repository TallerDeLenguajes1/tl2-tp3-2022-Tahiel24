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
            }while(opcion<1&&opcion>4);
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
                        int numPedido,cade,op1,indice=0,indice2=0;
                        if (ListadoPedidosN.Any())
                        {
                            while (op1 != 2)
                            {
                                if (ListadoPedidosN.Any()) {
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
                                Console.WriteLine("Seleccione el nro de pedido e id cadete a asignar:");
                                Console.Write("Pedido: ");
                                numPedido=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("/n");
                                Console.WriteLine("Cadete: ");
                                cade=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("/n");
                                foreach(var i in ListadoCadetes)
                                {
                                    if (i.Id == cade)
                                    {
                                        break;
                                    }else{
                                        indice++;
                                    }
                                }
                                foreach(var i in ListadoPedidosN)
                                {
                                    if (i.Nro == numPedido)
                                    {
                                            ListadoCadetes[indice].ListadoPedidos.Add(i);
                                            break;
                                    }else{
                                        indice2++;
                                    }
                                }
                                ListadoPedidosN.Remove(ListadoPedidosN[indice2]);
                                Console.WriteLine("Desea agregar mas pedidos o salir?(1:salir, 2:seguir ");
                                do
                                {
                                    op1=Convert.ToInt32(Console.ReadLine());
                                }while(op1<1&&op1>2);

                                }
                                else
                                {
                                    Console.WriteLine("La lista de pedidos esta vacia, no puede asignarse a mas cadetes");
                                    break;
                                }
                            }
                            Console.WriteLine("Pedidos movidos con exito");
                        }
                        else
                        {
                            Console.WriteLine("La lista de pedidos esta vacia, ingrese pedidos al sistema primero(Opcion 1)");
                            break;
                        }
                case 3:
                        int op3,idC,idP,est,cont=0,cont1=0;
                        bool comp=false;
                        Console.WriteLine("Listado de pedidos y su estado: ");
                        for (int i = 0; i < ListadoCadetes.Count; i++)
			            {
                            foreach(var i in ListadoCadetes[i].ListadoPedidos)
                            {
                                Console.WriteLine("Listado de pedidos y su estado(0:entregado,1:no entregado): ");
                                Console.WriteLine("Id de cadete: " + ListadoCadetes[i].Id +"- Id de pedido: "+i.Nro+ "- Estado: "+i.Estado);
                            }
			            }

                        while (op3 != 2)
                        {
                            for (int i = 0; i < ListadoCadetes.Count; i++)
			                {
                                foreach(var i in ListadoCadetes[i].ListadoPedidos)
                                {
                                    Console.WriteLine("Listado de pedidos y su estado(0:entregado,1:no entregado): ");
                                    Console.WriteLine("Id de cadete: " + ListadoCadetes[i].Id +"- Id de pedido: "+i.Nro+ "- Estado: "+i.Estado);
                                }
			                }
                            Console.WriteLine("Ingrese id del cadete: ");
                            idC=Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese id del pedido ");
                            idP=Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Estado del pedido: (0:entregado,1:no entregado)");
                            est=Convert.ToInt32(Console.ReadLine());
                            
                            
                            for (int i = 0; i < ListadoCadetes.Count; i++)
			                {
                                if (ListadoCadetes[i].Id == idC && comp==false)
                                {
                                    for (int j = 0; j < ListadoCadetes[i].ListadoPedidos.Count; j++)
			                        {
                                        if (comp == false)
                                        {
                                            foreach(var i in ListadoCadetes[i].ListadoPedidos[j])
                                            {
                                               if (i.Nro = idP)
                                               {
                                                    if (i == 0)
                                                    {
                                                        i.Estado=est;
                                                        ListadoCadetes[i].ListadoEntregados.Add(i);
                                                        ListadoCadetes[i].ListadoPedidos.Remove(i);
                                                        comp=true;
                                                        break;
                                                    }
                                                    
                                                }
                                                else continue;
                                            }
                                        }else break;
                                        
			                        }
                                    
                                }else continue;
			                }
                            do
                            {
                                Console.WriteLine("Desea cambiar mas pedidos(1) o salir(2)?");
                                op3=Convert.ToInt32(Console.ReadLine());
                            }while(op3<1 && op3>2)
                        }
                        Console.WriteLine("Pedidos modificados con exito");
                        break;
                }
                Console.WriteLine("1_Dar de alta pedidos ");
                Console.WriteLine("2_Asignarlos a cadetes ");
                Console.WriteLine("3_Cambiar de estado el pedido");
                Console.WriteLine("4_Cambiar pedidos de cadetes");
                Console.WriteLine("5_Dar por finalizado el dia");
                do
                {
                    opcion=Convert.ToInt32(Console.ReadLine());
                }while(opcion<1&&opcion>5);
            }
            int contFinal,valor;
            Console.WriteLine("Dia finalizado, balance final: ");
            foreach(var i in ListadoCadetes)
            {
                valor=i.JornalACobrar();
                Console.WriteLine("Nombre del cadete: "+i.Nombre+"- ID: "+i.Id+"- Cantidad de pedidos entregados: "+i.ListadoEntregados.Count+"- Jornal a cobrar: "+valor);
            }
        }
    }
}
