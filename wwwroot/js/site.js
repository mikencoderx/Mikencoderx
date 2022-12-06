

const cuadro1 = document.getElementById('imagen_1');
const cuadro2 = document.getElementById('imagen_2');
const cuadro3 = document.getElementById('imagen_3');
const cuadro4 = document.getElementById('imagen_4');
const cuadro5 = document.getElementById('imagen_5');
const cuadro6 = document.getElementById('imagen_6');
const cuadro7 = document.getElementById('imagen_7');

const cargar_cuadro = (entradas, observador) => {
    entradas.forEach(entrada => {
        if (entrada.isIntersecting) {
            entrada.target.classList.add('visible');
        }
    });
}

const observador = new IntersectionObserver(cargar_cuadro, {
    root: null,
    rootMargin: '0px',
    threshold: 0.2
});

observador.observe(cuadro1);
observador.observe(cuadro2);
observador.observe(cuadro3);
observador.observe(cuadro4);
observador.observe(cuadro5);
observador.observe(cuadro6);
observador.observe(cuadro7);
