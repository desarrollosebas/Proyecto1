## Sistema de Clasificación de Pedidos

### Descripción General
Una tienda en línea necesita un programa que, dados los datos de un pedido, determine su **categoría de despacho** y el **costo de envío**.

---

## Análisis IPO (Entrada - Proceso - Salida)

### **ENTRADAS**
- Monto del pedido (decimal)
- Ciudad destino (string)
- Tipo de cliente: "nuevo" o "recurrente" (string)
- Cantidad de items (int)

### **PROCESOS**
- Validar que el monto sea mayor a 0
- Validar que la cantidad de items sea mayor a 0
- Validar el tipo de cliente (nuevo o recurrente)
- Aplicar reglas de clasificación:
  - **Envío gratis** si monto ≥ $150.000 Y cliente recurrente
  - **Envío express** si items ≥ 5 O monto ≥ $300.000
  - **Envío estándar** en todos los demás casos
  - **Costo adicional** si ciudad destino es "exterior"
- Calcular costo de envío según la categoría

### **SALIDAS**
- Categoría de despacho (string)
- Costo de envío (decimal)
- Mensaje al cliente (string)

---

## Tabla de Variables

| # | Nombre Variable | Tipo Dato | Descripción | Rango/Valores |
|---|---|---|---|---|
| 1 | `monto_pedido` | decimal | Monto total del pedido | > 0 |
| 2 | `ciudad_destino` | string | Ciudad de envío del pedido | cualquier ciudad o "exterior" |
| 3 | `tipo_cliente` | string | Clasificación del cliente | "nuevo" o "recurrente" |
| 4 | `cantidad_items` | int | Cantidad de artículos en el pedido | > 0 |
| 5 | `categoria_despacho` | string | Categoría del envío asignada | "gratis", "express", "estándar" |
| 6 | `costo_envio` | decimal | Costo del envío calculado | ≥ 0 |
| 7 | `es_destino_exterior` | boolean | Determina si destino es exterior | true / false |
| 8 | `mensaje_cliente` | string | Mensaje informativo al cliente | texto descriptivo |
| 9 | `costo_adicional` | decimal | Costo adicional por exterior | ≥ 0 |

---

## Reglas de Implementación

| Condición | Categoría | Costo Base |
|---|---|---|
| monto ≥ $150.000 Y cliente = "recurrente" | Gratis | $0 |
| items ≥ 5 O monto ≥ $300.000 | Express | A determinar |
| Todos los demás casos | Estándar | A determinar |
| Si ciudad = "exterior" | Costo Adicional | A determinar |

---

## Requerimientos Técnicos

- **Tipos de datos mínimos**: decimal, string, int
- **Operadores**: aritméticos, relacionales y lógicos (&&, \|\|)
- **Condicionales**: ≥ 3 anidadas o con condiciones compuestas
- **Complejidad**: Decisiones de diseño reales sobre cuándo se aplica cada regla

