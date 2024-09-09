# Taller de Lenguajes II - Trabajo Practico N°1

## Ejercicio 2-a)

- Las relaciones de agregación son entre los pedidos y el cadete ya que un cadete puede llevar más de un pedido y no deja existir si no tiene pedidos que realizar. Por otro lado, las relaciones de composición se dan entre cliente y pedido, cadete y cadeteria, ya que el cliente depende que exista el pedido, y el cadete depende de que exista la cadeteria.

- A la clase cadete le añadiría los métodos TomarPedido, EntregarPedido, JornalACobrar, CambiarEstadoPedido y ReasignarPedidos. Para la clase cadeteria le añadiría los métodos ContratarCadete, DespedirCadete, PagarJornal, AltaPedido, AsignarPedido, CambiarEstadoPedido, ReasignarPedidos y GenerarInforme.

- Los atributos privados serian Nombre, Dirección, Teléfono y DatosReferenciaDireccion de la clase Cliente. Nro, Obs, Cliente y Estado de la clase Pedidos. Id, Nombre, Dirección, Teléfono, ListadoPedidos y ListadoPedidosEntregados de la clase Cadete. Nombre, Teléfono y ListadoCadetes de la clase Cadetería. Por otro lados las propiedades y los métodos propuestos deben ser públicas, las propiedades para poder acceder a los campos/atributos privados y los métodos para poder usarlos fuera de las clases.

- Los constructores de las clases Pedidos y Cadeteria deben contener las nuevas instancias de las clases Cliente y Cadete para tener la dependencia de composición. Las clases de Cliente y Cadete pueden tener sus respectivos constructores vacíos como vienen por defecto.

- Otro diseño posible es que la clase Cadeteria tenga la lista de pedidos para poder repartir entre los diferentes cadetes.