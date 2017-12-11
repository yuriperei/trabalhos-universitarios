$(document).ready(function(){
    var jogo = {
        cartas : ['img/android.png','img/chrome.png', 'img/facebook.png', 'img/firefox.png', 'img/googleplus.png', 'img/html5.png', 'img/twitter.png', 'img/windows.png'],
        statusJogo : 'Selecione uma carta',
        inicio: function(){    
            //zera variavel de status
            //sorteio
            //exibefechado
            jogo.statusJogo = 'Selecione uma carta';
            $('#statusjogo').text(jogo.statusJogo);
            jogo.sorteia();
            $('.carta').bind('click',function(evento){
                console.log(evento);
               div = evento.target;
               jogo.validaJogada(div);
            });
            jogo.exibeFechado();
            },
        sorteia: function(){
            //para cada carta, atribui se é coringa ou nao
            //atribui click
            for(let i = 1; i < jogo.cartas.length; i++){
                     random = Math.round(Math.random() * i);
                     temp = jogo.cartas[i];
                     jogo.cartas[i] = jogo.cartas[random];
                     jogo.cartas[random] = temp;
                 }
            $('.carta').each( function(indice){
                $(this).attr('data-card-value', jogo.cartas[indice]);
            })
        },
        exibeFechado: function(){ 
            //mostra todo mundo verso.jpg
            $('.carta').each(function(indice){
                console.log($(this));
                $('.carta')[indice].src = 'img/verso.png';
            });
        },
        validaJogada: function(div){     
            //ve se acertou
            //exibe cartas
            console.log($(div).attr('data-card-value'));
            if($(div).attr('data-card-value') == 'coringa.jpg'){
                jogo.statusJogo='Ganhou!';
            }else{
                jogo.statusJogo='Errrrou!';
            }
            console.log(jogo.statusJogo);
            $('#statusjogo').text(jogo.statusJogo);
            $('.carta').each(function(indice){
                console.log($(this).attr('data-card-value'));
                
                //$(this).src = $(this).attr('data-card-value');
                $('.carta')[indice].src=$(this).attr('data-card-value')
                console.log($('.carta')[indice].src);
            })
        }
        
    } ;
    jogo.inicio();
    $('#novojogo').click(function(){
        jogo.inicio();
    })
 });