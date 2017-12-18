$(document).ready(function () {
    var jogo = {
        cartas: ['img/android.png', 'img/android.png',
            'img/chrome.png', 'img/chrome.png',
            'img/facebook.png', 'img/facebook.png',
            'img/firefox.png', 'img/firefox.png',
            'img/googleplus.png', 'img/googleplus.png',
            'img/html5.png', 'img/html5.png',
            'img/twitter.png', 'img/twitter.png',
            'img/windows.png', 'img/windows.png'
        ],
        cardEscolhido: null,
        time: null,
        jogar: true,
        acertos: 0,
        erros: 0,
        inicio: function (status) {
            $('#statusjogo').text(status);

            jogo.acertos = 0;
            jogo.erros = 0;
            jogo.time = null;
            $('#time').text('');

            jogo.time = new Date().getTime();
            $('#ptsAcerto').text("Acertos: " +jogo.acertos);
            $('#ptsErro').text("Erros: " + jogo.erros);

            jogo.sorteia();
            jogo.exibeFechado();

            $('.carta').bind('click', function (evento) {
                div = evento.target;
                jogo.validaJogada(div);
            });
        },
        sorteia: function () {
            for (let i = 0; i < jogo.cartas.length; i++) {
                random = Math.round(Math.random() * (jogo.cartas.length - 1));

                temp = jogo.cartas[i];
                jogo.cartas[i] = jogo.cartas[random];
                jogo.cartas[random] = temp;
            }
            $('.carta').each(function (indice) {
                $(this).attr('card-value', jogo.cartas[indice]);
                $(this).attr('card-on', true);
                //Exibe a carta
                $(this).attr('src', jogo.cartas[indice]);
            })
        },
        exibeFechado: function () {
            //mostra todo mundo verso.jpg

            $('.carta').fadeOut(3000, function () {
                $('.carta').attr('src', 'img/verso.png');
                $('#statusjogo').text('Selecione uma carta');
            }).fadeIn(50);

            // $('.carta').each(function(indice){
            //     $('.carta')[indice].fadeOut(400, function(){
            //         $('.carta')[indice].src = 'img/verso.png';
            //     }).fadeIn(400);

            // });
        },
        validaJogada: function (div) {

            if (jogo.jogar) {
                //Exibe carta e coloca attr selected
                $(div).attr('src', $(div).attr('card-value'));
                // console.log($(div).attr('card-on'));
                // console.log(eval($(div).attr('card-on')));

                if (jogo.cardEscolhido != null && eval($(div).attr('card-on'))) {
                    var cardEscolhido = jogo.cardEscolhido;
                    //VERIFICA SE ACERTOU
                    if ($(cardEscolhido).attr('card-value') == $(div).attr('card-value')) {
                        $(cardEscolhido).attr('card-on', false);
                        $(div).attr('card-on', false);
                        jogo.acertos++;

                        $('#statusjogo').text('Aceerrtoou!! Selecione uma carta'); 
                        $('#ptsAcerto').text("Acertos: " +jogo.acertos);

                        if (jogo.acertos == 8) {
                            $('#statusjogo').text('Você venceu o jogo!');
                            var fechoPagina = new Date().getTime();
                            jogo.time = new Date(fechoPagina - jogo.time);
                            $('#time').text("Tempo: " + jogo.time.getMinutes() + ':' + jogo.time.getSeconds());
                        }
                    } else {
                        jogo.jogar = false;
                        jogo.erros++;
                        setTimeout(function () {
                            $(cardEscolhido).attr('src', 'img/verso.png');
                            $(div).attr('src', 'img/verso.png');
                            jogo.jogar = true;
                        }, 1500);
                        $(cardEscolhido).attr('card-on', true);
                        $('#statusjogo').text('Erroouu!! Selecione uma carta'); 
                        $('#ptsErro').text("Erros: " + jogo.erros);
                    }
                                       
                    jogo.cardEscolhido = null;
                } else if (eval($(div).attr('card-on'))) {
                    $(div).attr('card-on', false)
                    jogo.cardEscolhido = div;
                    $('#statusjogo').text('Ache outra carta igual!');
                }
            }
        }
    }

    $('#novojogo').click(function () {
        $('#statusjogo').text("Aguarde, estamos preparando tudo!");

        setTimeout(function () {
            jogo.inicio("O jogo irá começar. Prepare-se!");
        }, 1500);

        $('.carta').bind('click', function (evento) {
            div = evento.target;
            jogo.validaJogada(div);
        });
    })


});

// var Jogo = function () {
//     this.cartas = ['img/android.png', 'img/android.png',
//         'img/chrome.png', 'img/chrome.png',
//         'img/facebook.png', 'img/facebook.png',
//         'img/firefox.png', 'img/firefox.png',
//         'img/googleplus.png', 'img/googleplus.png',
//         'img/html5.png', 'img/html5.png',
//         'img/twitter.png', 'img/twitter.png',
//         'img/windows.png', 'img/windows.png'
//     ];
//     this.statusJogo = 'Selecione uma carta';
//     this.cardEscolhido = null;
//     this.jogar = true;
//     this.time = null;
//     this.acertos = 0;
//     this.erros = 0;
//     this.inicio = function (status) {
//         $('#statusjogo').text(status);

//         this.time = new Date().getTime();

//         this.sorteia(this.cartas);
//         this.exibeFechado(this.statusJogo);
//     };
//     this.sorteia = function (cartas) {
//         for (let i = 0; i < cartas.length; i++) {
//             random = Math.round(Math.random() * (cartas.length - 1));

//             temp = cartas[i];
//             cartas[i] = cartas[random];
//             cartas[random] = temp;
//         }
//         $('.carta').each(function (indice) {
//             $(this).attr('card-value', cartas[indice]);
//             $(this).attr('card-on', true);
//             //Exibe a carta
//             $(this).attr('src', cartas[indice]);
//         })
//     };
//     this.exibeFechado = function (status) {
//         //mostra todo mundo verso.jpg
//         $('.carta').fadeOut(3000, function () {
//             $('.carta').attr('src', 'img/verso.png');
//             $('#statusjogo').text(status);
//         }).fadeIn(50);
//     };
//     this.validaJogada = function (div) {

//         if (this.jogar) {
//             //Exibe carta
//             $(div).attr('src', $(div).attr('card-value'));
//             // console.log($(div).attr('card-on'));
//             // console.log(eval($(div).attr('card-on')));

//             if (this.cardEscolhido != null && eval($(div).attr('card-on'))) {
//                 var cardEscolhido = this.cardEscolhido;
//                 //VERIFICA SE ACERTOU
//                 if ($(cardEscolhido).attr('card-value') == $(div).attr('card-value')) {
//                     //Exibe ponto
//                     //RETIRAR ATRIBUTO CARD-VALUE
//                     console.log("Acertou");
//                     $(cardEscolhido).attr('card-on', false);
//                     $(div).attr('card-on', false);
//                     this.acertos++;
//                     if (this.acertos == 8) {
//                         this.statusJogo = 'Você venceu o jogo!';
//                         var fechoPagina = new Date().getTime();
//                         this.time = (fechoPagina - this.time) / 1000;
//                         console.log(time);
//                     }
//                 } else {
//                     this.jogar = false;
//                     this.erros++;
//                     setTimeout(function () {
//                         $(cardEscolhido).attr('src', 'img/verso.png');
//                         $(div).attr('src', 'img/verso.png');
//                         this.jogar = true;
//                     }, 1500);
//                     $(cardEscolhido).attr('card-on', true);
//                 }
//                 this.cardEscolhido = null;
//             } else if (eval($(div).attr('card-on'))) {
//                 $(div).attr('card-on', false)
//                 this.cardEscolhido = div;
//             }
//         }
//     };
// };

