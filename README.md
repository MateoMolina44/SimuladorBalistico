# Simulador Balístico

Simulador desarrollado en Unity donde el jugador ajusta ángulo, fuerza y masa de un proyectil para impactar objetivos, con registro de resultados de cada disparo.

## Video demostrativo

[Ver video en YouTube](https://youtu.be/keF4kFV1EiM)

## Versión de Unity

Unity 6000 (Unity 6)

## Cómo jugar

1. Abrí la escena principal y entrá en modo Play.
2. Configurá el disparo usando los sliders de la interfaz: ángulo (ejes Y/Z), fuerza y masa del proyectil.
3. Presioná **Espacio** para disparar.
4. El proyectil viaja con física real (Rigidbody) hasta impactar el suelo o un objetivo.
5. Al impactar, se registra automáticamente el resultado del tiro (distancia recorrida, tiempo de vuelo, ángulo, fuerza y masa utilizados) en el historial visible en pantalla.
6. Repetí el proceso ajustando los parámetros para mejorar precisión y potencia en los siguientes intentos.

## Controles

| Acción | Control |
|---|---|
| Disparar | Tecla **Espacio** |
| Ajustar ángulo (eje Y) | Slider de ángulo Y |
| Ajustar ángulo (eje Z) | Slider de ángulo Z |
| Ajustar fuerza de disparo | Slider de fuerza |
| Ajustar masa del proyectil | Slider de masa |

Cada slider actualiza su valor correspondiente en tiempo real y lo refleja en el texto de la interfaz antes de disparar.

## Objetivo del proyecto

Construir un simulador balístico donde el jugador regula ángulo, fuerza y masa del proyectil para derribar objetivos, gobernando el disparo y las colisiones mediante Rigidbody y el sistema de físicas de Unity, registrando los resultados de impacto para evaluar precisión y potencia.

## Criterios de evaluación

**Controles de disparo en pantalla**
- Ángulo y fuerza configurables mediante Slider.
- Masa del proyectil seleccionable.

**Disparo físico**
- Proyectil con Rigidbody y Collider.
- Lanzamiento mediante AddForce según el ángulo y la fuerza configurados.

**Escena de objetivos**
- Estructuras armadas con Rigidbodies y Joints (FixedJoint, HingeJoint o SpringJoint).
- Estabilidad inicial correcta: los objetivos no deben caerse solos si están bien configurados.

**Registro del resultado**
- Se guardan datos de tiempo de vuelo, punto de impacto (distancia), velocidad relativa, impulso de colisión y piezas derribadas.
- Se muestra un historial con el reporte de cada intento realizado durante la sesión.
