var Forca = function(dicPalavras, divErros, divAcertos) {
    this.erros = '';
    this.acertos = '';
    this.lacunas = '';
    this.palavras = dicPalavras;
    this.palavraSorteada = '';

    this.inicia = function() {
        this.acertos = '';
        this.erros = '';
        this.lacunas = '';
        //Coloca conteudo em um html
        this.exibeHTML(divAcertos, this.acertos.length);
        this.exibeHTML(divErros, this.erros);
        this.palavraSorteada = this.palavras[Math.floor(Math.random() * this.palavras.length)];
        for (var i = 0; i < this.palavraSorteada.length; i++) {
            this.lacunas += ' _ ';
        };
        this.exibeHTML(divAcertos, this.lacunas);
        // document.onkeypress = (evt)=>{
        //     evt = evt || window.event;
        //     var charCode = evt.keyCode || evt.which;
        //     var charStr = String.fromCharCode(charCode);
        //     this.verificaLetra(charStr);
        // }
    };

    this.verificaStatusJogo = () => {
    
        if(this.erros.length >= 5){
            console.log("perdeu playboy");            
        }

        if(this.lacunas.indexOf('_',0) == -1){
            console.log("ganhou");
        }
    };

    this.exibeHTML = function(a, b) {
        // document.getElementById(a).innerHTML = b;
    };
    
    this.verificaLetra = (letra) => {   
        if(this.palavraSorteada.indexOf(letra,0) != -1){
            this.verificaAcerto(letra);
        }else{
            this.adicionaErro(letra);
        }
        this.atualizaHtml();
    };

    this.verificaAcerto = function(letra){
        if(this.acertos.indexOf(letra, 0) == -1){
            this.adicionaNovoAcerto(letra);
        }
    }
    
    this.adicionaNovoAcerto = function(letra){
        this.acertos += letra;
    }
    
    this.adicionaErro = function(letra){
        if(this.erros.indexOf(letra, 0) == -1){
            this.adicionaNovoErro(letra);
        }
    }

    this.adicionaNovoErro = function(letra){
        this.erros += letra;
    }

    this.atualizaHtml = () =>{
        this.exibeHTML(divErros, this.erros);
        this.lacunas = '';
        for(var i=0; i< this.palavraSorteada.length; i++){
            console.log('letraSort='+this.palavraSorteada.charAt(i));
            console.log('acertos='+this.acertos);

            if(this.acertos.indexOf(this.palavraSorteada.charAt(i)) != -1) {
                this.lacunas += this.palavraSorteada.charAt(i) + ' ';
            }else{
                this.lacunas += ' _ ';
            }
        }
        this.exibeHTML(divAcertos,this.lacunas);
        this.verificaStatusJogo();
    }

};

// window.onload = function () {
//     var partida = new Forca(["mineral", "dinossauro", "quadrilha", "vampiro","carro", "luar", "jangada"], "erros", "palavra");
//     partida.inicia();
// };

module.exports = Forca;