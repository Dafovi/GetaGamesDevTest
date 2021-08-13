![](https://i.postimg.cc/kGtGHkxP/Banner.png)

# GetaGamesDevTest
Este es el repositorio para la prueba técnica de desarrollador en Unity de [GetaClub](https://www.getaclub.io/es/ "GetaClub"), enviada el 06/08/2021 por Durley López, CTO de GetaClub.

El proyecto base en la versión de Unity 2020.3.3f tomado del repositorio de [JuanDevGeta](https://github.com/JuanDevGeta/GetaGamesDevTest "JuanDevGeta"). Además se agrego el canal de renderizado [High Definition Render Pipeline (HDRP)](https://unity.com/es/srp/High-Definition-Render-Pipeline "High Definition Render Pipeline (HDRP)").

------------

------------
## RaceKart
Este proyecto cuenta con 2 modos de juego "**Carrera contrarreloj**"y "**Carrera de distancia**", las cuales son accesibles a través de un menú principal "MainMenu" con una escena intermedia de carga "Loading" en la cual se muestran los controles e instrucciones del modo seleccionado.

------------

### Carrera Contrareloj
Se trata de una carrera en la cual se debe recorrer un circuito antes de que se acabe el tiempo.
Este modo de juego cuenta con:
- Control por teclado del "kart", movimiento de izquierda, derecha, acelerar, frenar y derrape.
- Tiempo en UI que va decreciendo segundo a segundo.
- Objeto que al ser tomado por el "kart" suma tiempo para permitir seguir jugando.
- Turbo o aumento de velocidad que al ser tocado el "kart" aumentará su velocidad
- Objeto que al ser tocado por el "kart", este pierde el control durante un corto periodo de tiempo.
- Guardado de información de la sesión y de estadísticas: carreras jugadas, carreras ganadas y récord de la vuelta mas rápida.

![](https://raw.githubusercontent.com/Dafovi/GetaGamesDevTest/master/Assets/Mod%20Assets/ModResources/Textures/IntroSceneBackgrounds/TimeRace.png)


------------

### Carrera de distancia
Acá el "kart" acelera solo por una pista de obstáculos que se generan aleatoriamente, mientras mas se avanza mayor será la velocidad.
Este modo de juego cuenta con:
- Control por teclado del "kart", movimiento de izquierda y derecha.
- Distancia en UI que va aumentando según la distancia recorrida.
- Objetos que al ser tocados darán por terminada la carrera.
- Guardando de información de la sesión y de estadísticas: carreras jugadas y récord de distancia.

![](https://raw.githubusercontent.com/Dafovi/GetaGamesDevTest/master/Assets/Mod%20Assets/ModResources/Textures/IntroSceneBackgrounds/DistanceRace.png)

------------

### Editor de personaje
En esta pantalla podrás editar el color de:
- Personaje.
- Vehiculo.
- Ruedas del vehiculo.

Además se guardara la información de los colores seleccionados para los 2 modos de juego y las siguientes sesiones.

<img src="https://i.postimg.cc/90r15cpM/Personalizacion.png" alt="drawing" width="600"/>

------------
**Puedes Descargar El Proyecto Exportado (Build) [Aquí.](https://drive.google.com/file/d/1C53M_-X5anDBuWH-t946NUywijhIPJON/view?usp=sharing "Aquí.")**

------------

#### Elementos de terceros
Modelos extra: https://assetstore.unity.com/packages/templates/karting-microgame-150956

Banana Model: "Banana Peel (Mario Kart)" (https://skfb.ly/6EvGw) by Anthony Yanez is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

Sonidos de mario kart 64 : https://themushroomkingdom.net/media/mk64/wav

Skybox: https://assetstore.unity.com/packages/vfx/shaders/free-skybox-extended-shader-107400

Reloj (StopWatch): https://www.turbosquid.com/3d-models/stopwatch-ussr-3d-1212541

Scripts movimiento de personaje y creación del mapa para el juego extra "EndlessGame": https://www.youtube.com/playlist?list=PL0WgRP7BtOez8O7UAQiW0qAp-XfKZXA9W

Logo Geta Club png: https://www.getaclub.io/wp-content/uploads/2020/09/geta-club.png