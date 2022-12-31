# OurGot

![](OutGot.png)

>Proyecto de Programacion I.
>Facultad de Matematica y Computacion. Universidad de la Habana 
>Cursos 2021, 2022

OutGot es un *minijuego* que tiene como objetivo implementar un interprete .

Fue implementado en primera instancia como consola y luego se le creo una aplicacion web desarrollada con tecnologia .Net Core 6.0/7.0 especificamente utilizando Blazor como *framework* web para la interfaz grafica, y en el lenguaje de C#.

La aplicacion esta divida en 3 Componentes fundamentales:

- `Pages` es donde se encuentran varios archivos .cs y tres paginas en donde se realiza el intercambio de informacion con el usuario.

- `Components` aqui se crearon los componentes principales del juego.

- `Models` estrechamente relacionada con components se le dan propiedades a los mismos.


Ademas de un archivo .css para darle vida a los componentes de la pagina.

Para el entendimiento del Correcto fucionamiento del Proyecto es necesario empezar por los siguientes archivos del `Pages`:

- `Card` :

    donde se guarda la informacion de la carta, posee un metodo para imprimir en consola, *inutilazado*.

- `Context`

    en primera instancia es un diccionario en donde se puede guardar y obtener informacion del estado del juego se usa para evaluar las condiciones de las cartas

- `Player`

    Es una clase de la que hereda virtual player en un princpio se utilizaba para interactuar por consola pero la mayoria de sus metodos ya son, *inutilizados* pero consideramos dejarlos fue un bonito trabajo

- `Token`

    En esta clase se tiene un conjunto de palabras claves que pueden estar en una carta y su principal trabajo es tomar un string e identificar su tipo y almacenar su valor ayuda mucho el proceso de lexxer y parsing

- `Virtual Player`

    ////////

Son clases fundamentales en el program pues son reutilizables y reducen el codigo.

Luego tenemos que centrar otra base de nuestro proyecto Expressions, consideramos como Expresion cualquier cosa que sea evaluable luego Expresion sera un interfaz necesaria para implementar nuesto arbol de sintaxis abstracta que contiene varias operaciones:


### Binary :

Digase de todas las Expresiones compuestas por dos expresiones luego el resultado de la expresion binaria es equivalente a evaluar ambas expresiones que la componen y realizar alguna operacion con ellas.

A continuacion se diran cada expresion con su respectiva operacion.
```yml
Logicas:

    And : "y logico (^)" devuelve 1 si el resultado de evaluar ambas expresiones son distintos de 0, de lo contario 0.  

    Or : "o logico (||)" devuelve 1 si el resultado de evaluar alguna de las expresiones es distinto de 0, de lo contario 0.


Aritmeticas:
    Sum : "suma (+)" devuelve la suma de evaluar ambas expresiones.

    Sub : "substraccion (-)" devuelve la resta de evaluar ambas expresiones, la primera menos la segunda.

    Div : "division (/)" devuelve la divison de evaluar ambas expresiones la izquierda entre la derecha.

    Mult : "multiplicacion (*)" devuelve la multiplicacion de evaluar ambas expresiones.

Desigualdades:
    Se considera miembro izquierdo como expresion izquierda y miembro derecho como expresion derecha

    Iqual : "Igualdad (==)" devuelve 1 si al evaluar ambas expresiones son iguales.

    Minus : "Menor que (<)" devuelve 1 si al evaluar ambas expresiones la izquierda es menor que la derecha en caso contrario 0.

    Higher : "Mayor que (>)" devuelve 1 si al evaluar ambas expresiones la izquierda es mayor que la derecha en caso contrario 0.
```

Luego tenemos las expresiones unarisa un poco mas sencillas.

### Unary:
Compuesto por una expresion a la cual se le aplica algun criterio para devolver cierto valor.

    Var : Se busca en el context alguna variabel con nombre igual a al Var analizando y se retorna su valor en caso de existir 

    Constant : Se tienen valores constantes como "1 2 4352 35426 ect".

Ademas de estas Classes IExpresables se tiene la clase Action que es un arbol paralelo a Expresiones lo que aqui ya esta presente nuestra creatividad

Se tienen unos poderes basicos como *To attack*,*Up attack*
*Up defense*,*Up range*,*Tade*, *Sacrifice*.

Luego se tienen unos poderes que se basan en los primeros *During* y *TimeAction* estos toman uno de los poderes basicos o combinaciones de ellos y los ejecutan repetidamente o por turnos respectivamente. Por problemas de cambio de informacion con la pagina web hemos tenido que dejar de lado los *TimeAction*.

El metodo Evaluate de las Actions llama a un metodo interno de las Actions abstracto para desarrollar en cada accion por separado digase modificar alguna propiedad de la carta, revivir o el dinero de algun jugador, teniendo las acciones modeladas como expresiones es legal llevar a cabo algunas operaciones con ellas digase And para asi concatenar varios poderes en uno

Una parte fundamental de nuestro proyecto es el proceso de creacion de cartas que pasa por dos estados Lexxer, Parsing comenzemos con el Lexxer.

### Lexxer :
    Se toma dos entradas del usuario la primera como identificara a la carta y luego se tiene una entrada para llenar las cualidades de la carta aqui se verifica con ayuda del proceso de tokenizacion si la carta esta bien escrita pasando por una serie de filtros y en caso de tener errores seran almacenados para luego mostrar en pantalla.

    Esta clase esta compuesta por varios metodos triviales pero para mejor lectura del codigo son necesarios digase los metodos del tipo Is_****, luego de tokenizado la entrada pasa por un check principal que se apoya de un check_expresion y check_condition: estos metodos son en primera instancia para verificar la correctitud de la entrada 

### Parser :
    Luego de pasado por el Lexxer se toma la identificacion de la carta y el contenido de ella ya tokenizado y se manda al parser. Aqui el metodo principal es el parsing en donde se atribuye a cada campo su valor. Apoyandose de metodos como cut_powers, cut_conditions.

    Importante resaltar el metodo de resolucion de expresiones utilizado en donde nos aprovechamos de la pila de recursivad para resolver una expresion dada por tokens. Se toma las operaciones en orden inverso y se llama nuevamente al metodo ignorando las expresiones que esten dentro de parentesis, ect teniendo en cuenta varias condiciones.

Tambien se tiene una clase Methods auxiliares del play se tienen metodos como : `Move`,`Validate_Position`,`Continue`,`On Range`,`Distance`,`Get_random`,`Read_Tab`,`End_Game`. Estos metodos son bastante explicitos y simples pero son bastante reutilizables algunos quedaron inutilizados como `Read_Tab`.

Alguna informacion auxiliar se guarda en el content y en el wwwroot/Img. En el proceso de creacion de la carta esta crea un fichero en el content que luego se leera para crear la carta