var forca = require('./app');


QUnit.test( "teste palavras", ( assert ) =>{
    var partida = new forca(
        ["mineral", "dinossauro", "quadrilha",
    "vampiro","luar","jangada","abacaxi"],
    "erros",
    "palavra"
    );
    
    partida.inicia();
  /*TEM QUE EXISTIR*/
  assert.ok( partida.palavras.indexOf("dinossauro") != "-1", 
  "Tem que existir!" );
  /*TEM QUE NÃO EXISTIR*/
  assert.ok( partida.palavras.indexOf("walkingdead") == "-1", 
  "Não é pra existir!" );
  /*TEM QUE NÃO EXISTIR*/
  assert.notOk( partida.palavras.indexOf("walkingdead") != "-1", 
  "Não é pra existir!" );
/* VAI DAR ERRRO!!!!!!*/
  //assert.ok( partida.palavras.indexOf("luar") == "-1", 
  //"Vai dar erro!" );

});
QUnit.test("teste de acertos", (assert)=>{
    var partida = new forca(
        ["mineral", "dinossauro", "quadrilha",
    "vampiro","luar","jangada","abacaxi"],
    "erros",
    "palavra"
    );
    
    partida.inicia();
    //fixture
    //partida.palavraSorteada = "saltimbancos";
    partida.verificaLetra("z");
    //partida.verificaLetra("a");
    //partida.verificaLetra("c");
    //partida.verificaLetra("o");
    //console.log(partida.getAcertos());
    //console.log(partida.getErros());
    assert.notOk(partida.getAcertos().length > 0 , "Z não é um acerto");
    //console.log(partida.getErros());
    assert.ok(partida.getErros().length > 0 , "Z é um erro");
    partida.verificaLetra("a");
    partida.verificaLetra("e");
    partida.verificaLetra("i");
    partida.verificaLetra("o");
    partida.verificaLetra("u");
    

    assert.ok(partida.getErros().length ==1 , "Z é O erro");
    var totalErros = partida.getErros();
    partida.verificaLetra("z");
    assert.ok(partida.getErros().length == totalErros , "Z não contabilizou de novo");

    
    
});