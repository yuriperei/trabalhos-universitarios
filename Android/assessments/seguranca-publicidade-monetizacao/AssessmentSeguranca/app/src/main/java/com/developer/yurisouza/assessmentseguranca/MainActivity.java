package com.developer.yurisouza.assessmentseguranca;

import android.content.Context;
import android.os.Bundle;
import android.os.SystemClock;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.android.gms.ads.AdListener;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.InterstitialAd;

import java.io.FileOutputStream;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import br.com.sapereaude.maskedEditText.MaskedEditText;

public class MainActivity extends AppCompatActivity {

    EditText txtNome;
    EditText txtEmail;
    EditText txtSenha;
    EditText txtRepetirSenha;
    MaskedEditText txtCpf;
    Button btnCadastrar;

    InterstitialAd mInterstitialAd;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("Cadastro de Usuário");

        txtNome = (EditText) findViewById(R.id.txtNome);
        txtEmail = (EditText) findViewById(R.id.txtEmail);
        txtSenha = (EditText) findViewById(R.id.txtSenha);
        txtRepetirSenha = (EditText) findViewById(R.id.txtRepetirSenha);
        txtCpf = (MaskedEditText) findViewById(R.id.txtCpf);
        btnCadastrar = (Button) findViewById(R.id.btnCadastrar);

        mInterstitialAd = new InterstitialAd(this);
        mInterstitialAd.setAdUnitId("ca-app-pub-3690489331222994/6527473158");
        mInterstitialAd.setAdListener(new AdListener() {
            @Override
            public void onAdClosed() {
                requestNewInterstitial();
            }
        });
        requestNewInterstitial();
    }

    private void requestNewInterstitial() {
        AdRequest adRequest = new AdRequest.Builder()
                .addTestDevice(AdRequest.DEVICE_ID_EMULATOR)
                .build();
        mInterstitialAd.loadAd(adRequest);
    }
    private void doSomeThing() {
        Toast.makeText(this, "Show Interstitial Ad", Toast.LENGTH_SHORT);
    }

    public void cadastrar(View view){
        if(isValidForm()){
            Context context = getApplicationContext();
            int duration = Toast.LENGTH_SHORT;

            if(writeFile()){
                CharSequence text = "Cadastrado com sucesso!";
                Toast toast = Toast.makeText(context, text, duration);
                toast.show();
                SystemClock.sleep(2500);

                if (mInterstitialAd.isLoaded()) {
                    mInterstitialAd.show();
                } else {
                    doSomeThing();
                }
            }else{
                CharSequence text = "Erro ao cadastrar!";
                Toast toast = Toast.makeText(context, text, duration);
                toast.show();
            }
        }
    }

    private boolean isValidForm(){
        int countError = 0;

        if(this.txtNome.getText().toString().length() == 0){
            this.txtNome.setError("O campo é obrigatório");
            countError++;
        }else if(!isValidName(this.txtNome.getText().toString())){
            this.txtNome.setError("Apenas letras é permitido");
            countError++;
        }

        if(this.txtEmail.getText().toString().length() == 0){
            this.txtEmail.setError("O campo é obrigatório");
            countError++;
        }else if(!isValidMail(this.txtEmail.getText().toString())){
            this.txtEmail.setError("Informe um e-mail válido");
            countError++;
        }

        if(this.txtSenha.getText().toString().length() == 0){
            this.txtSenha.setError("O campo é obrigatório");
            countError++;
        }

        if(this.txtRepetirSenha.getText().toString().length() == 0){
            this.txtRepetirSenha.setError("O campo é obrigatório");
            countError++;
        }else if(this.txtSenha.getText().toString().length() != 0 && !this.txtSenha.getText().toString().equals(this.txtRepetirSenha.getText().toString())){
            this.txtRepetirSenha.setError("As senhas não correspondem");
            countError++;
        }

        if(this.txtCpf.getText().toString().length() == 0){
            this.txtCpf.setError("O campo é obrigatório");
            countError++;
        }

        return countError == 0 ? true : false;
    }

    private boolean isValidMail(String email){
        String emailPattern ="^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
        Pattern pattern = Pattern.compile(emailPattern);
        Matcher isValid =  pattern.matcher(email);
        return isValid.matches();
    }

    private boolean writeFile(){
        String filename = this.txtNome.getText().toString() + "-" + this.txtCpf.getRawText();
        String string = "Nome:"+ this.txtNome.getText().toString() + ";" +
                "Email:"+ this.txtEmail.getText().toString() + ";" +
                "Senha:"+ this.txtCpf.getText().toString() + ";" +
                "Cpf:"+ this.txtCpf.getText().toString();
        FileOutputStream outputStream;

        try {
            outputStream = openFileOutput(filename, Context.MODE_PRIVATE);
            outputStream.write(string.getBytes());
            outputStream.close();
        } catch (Exception e) {
            return false;
        }
        return true;
    }

    private boolean isValidName(String email){
        String emailPattern ="^[ a-zA-Z áéíóú]*$";
        Pattern pattern = Pattern.compile(emailPattern);
        Matcher isValid =  pattern.matcher(email);
        return isValid.matches();
    }
}
