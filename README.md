# Sistema de Clasificación de Pedidos

## Descripción del Equipo

### Integrantes
- Sebastian Raigosa Gil

### Observaciones del Proyecto
Inicialmente el proyecto fue planteado en equipo junto con Arturo Andres Patiño Herrera. Sin embargo, durante el desarrollo del sistema, el integrante Arturo decidió retirarse del equipo, por lo que el proyecto continuó siendo desarrollado únicamente por Sebastian Raigosa Gil.

### Propuesta Seleccionada
Se desarrolla la **Propuesta A** planteada por el docente.

---

# Descripción General

Una tienda en línea requiere un sistema que permita clasificar automáticamente los pedidos según sus características, determinando la categoría de despacho y el costo de envío correspondiente.

Además de las funcionalidades iniciales, el sistema fue ampliado con nuevos procesos de análisis y control, permitiendo realizar cálculos adicionales como:

- Promedio de pedidos realizados.
- Cantidad total de pedidos procesados.
- Estadísticas básicas relacionadas con los envíos.
- Control y validación de información ingresada por el usuario.

Adicionalmente, el sistema será reestructurado desde una arquitectura monolítica hacia una estructura modular, permitiendo:

- Mejor organización del código.
- Separación de responsabilidades.
- Mayor facilidad de mantenimiento.
- Reutilización de funciones.
- Escalabilidad del proyecto.

La modularización divide el sistema en diferentes componentes independientes encargados de:
- Validaciones.
- Clasificación de pedidos.
- Cálculo de costos.
- Gestión de estadísticas.
- Mensajes al usuario.

---

# Análisis IPO (Entrada – Proceso – Salida)

## Entradas
El sistema recibe los siguientes datos:

- Monto total del pedido (`decimal`)
- Ciudad destino (`string`)
- Tipo de cliente (`string`)
- Cantidad de artículos (`int`)

---

## Procesos

El programa debe realizar las siguientes operaciones:

### Validaciones
- Verificar que el monto del pedido sea mayor a 0.
- Verificar que la cantidad de artículos sea mayor a 0.
- Validar que el tipo de cliente sea:
  - `"nuevo"`
  - `"recurrente"`

### Clasificación del Pedido
El sistema asignará una categoría de despacho aplicando las siguientes reglas:

#### Envío Gratis
Se aplica cuando:
- El monto del pedido es mayor o igual a `$150.000`
- Y el cliente es `"recurrente"`

#### Envío Express
Se aplica cuando:
- La cantidad de artículos es mayor o igual a `5`
- O el monto del pedido es mayor o igual a `$300.000`

#### Envío Estándar
Se aplica en todos los demás casos.

### Procesos Adicionales
El sistema también realiza:
- Conteo total de pedidos procesados.
- Cálculo del promedio de compras.
- Registro de estadísticas básicas del sistema.
- Acumulación de montos procesados.

### Costo Adicional
Si la ciudad destino es `"exterior"`, se agregará un costo adicional al envío.

### Reestructuración del Sistema
El código original será reorganizado mediante módulos y funciones independientes para mejorar:
- Legibilidad.
- Mantenimiento.
- Escalabilidad.
- Reutilización de código.

### Cálculo Final
El sistema calcula:
- Categoría del despacho.
- Costo total de envío.
- Mensaje informativo para el cliente.
- Promedio de pedidos.
- Cantidad de pedidos procesados.

---

## Salidas

El programa mostrará:

- Categoría de despacho.
- Valor del envío.
- Mensaje final para el cliente.
- Cantidad de pedidos registrados.
- Promedio de montos procesados.

---

# Tabla de Variables

| Nº | Variable | Tipo de Dato | Descripción | Valores / Restricción |
|----|-----------|---------------|-------------|------------------------|
| 1 | `monto_pedido` | decimal | Valor total del pedido | Mayor a 0 |
| 2 | `ciudad_destino` | string | Ciudad de entrega | Ciudad válida o `"exterior"` |
| 3 | `tipo_cliente` | string | Tipo de cliente | `"nuevo"` o `"recurrente"` |
| 4 | `cantidad_items` | int | Cantidad de artículos | Mayor a 0 |
| 5 | `categoria_despacho` | string | Tipo de envío asignado | `"gratis"`, `"express"` o `"estándar"` |
| 6 | `costo_envio` | decimal | Valor total del envío | Mayor o igual a 0 |
| 7 | `es_destino_exterior` | boolean | Indica si el destino es exterior | `true` / `false` |
| 8 | `mensaje_cliente` | string | Mensaje mostrado al usuario | Texto descriptivo |
| 9 | `costo_adicional` | decimal | Cargo extra por envío exterior | Mayor o igual a 0 |
| 10 | `cantidad_pedidos` | int | Número total de pedidos registrados | Mayor o igual a 0 |
| 11 | `promedio_pedidos` | decimal | Promedio de montos procesados | Mayor o igual a 0 |
| 12 | `acumulador_montos` | decimal | Suma total de pedidos procesados | Mayor o igual a 0 |

---

# Reglas de Implementación

| Condición | Categoría de Despacho | Costo Base |
|-----------|----------------------|-------------|
| Monto ≥ $150.000 y cliente recurrente | Envío Gratis | $0 |
| Cantidad de items ≥ 5 o monto ≥ $300.000 | Envío Express | Definido por el sistema |
| Cualquier otro caso | Envío Estándar | Definido por el sistema |
| Destino = `"exterior"` | Cargo adicional | Definido por el sistema |

---

# Requerimientos Técnicos

El desarrollo del sistema debe cumplir con las siguientes condiciones:

- Uso de tipos de datos:
  - `decimal`
  - `string`
  - `int`
  - `boolean`

- Implementación de operadores:
  - Aritméticos
  - Relacionales
  - Lógicos (`&&`, `||`)

- Uso de estructuras condicionales:
  - Condiciones compuestas.
  - Condicionales anidadas.

- Uso de funciones y módulos independientes para cada proceso principal.

- Separación lógica del sistema en:
  - Validaciones.
  - Procesamiento.
  - Estadísticas.
  - Resultados.

- El sistema debe reflejar decisiones de diseño reales para la clasificación automática de pedidos y cálculo de costos de envío.

---

# Objetivo del Sistema

Automatizar el proceso de clasificación y cálculo de envíos de pedidos en una tienda virtual, mejorando la eficiencia en la gestión logística y proporcionando información clara al cliente sobre el estado y costo de su despacho.

Además, se busca implementar una estructura modular que permita un desarrollo más organizado, escalable y mantenible del sistema.
