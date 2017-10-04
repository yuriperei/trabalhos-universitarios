package br.com.alfred.alfred.View.Evento;

import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TimePicker;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;

import br.com.alfred.alfred.Controller.EventoController;
import br.com.alfred.alfred.Model.Evento;
import br.com.alfred.alfred.R;
import br.com.alfred.alfred.Util.StringUtility;

public class EventoDetalheActivity extends AppCompatActivity {

    public EventoController controller;
    Evento evento;

    EditText txtNome;
    EditText txtDescricao;
    EditText txtLocal;
    EditText txtHoraInicio;
    EditText txtHoraFinal;
    EditText txtData;
    Button btnExcluir;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_evento_detalhe);
        this.controller = new EventoController(this);

        Intent intent = getIntent();

        btnExcluir = (Button) findViewById(R.id.button_excluir);

        txtNome = (EditText) findViewById(R.id.txtNome);
        txtDescricao = (EditText) findViewById(R.id.txtDescricao);
        txtLocal = (EditText) findViewById(R.id.txtLocal);

        txtHoraInicio = (EditText) findViewById(R.id.txtHoraInicio);
        formatTime(txtHoraInicio);

        txtHoraFinal = (EditText) findViewById(R.id.txtHoraFinal);
        formatTime(txtHoraFinal);

        txtData = (EditText) findViewById(R.id.txtData);
        formatDate(txtData);

        evento = (Evento) intent.getSerializableExtra("evento");
        if(evento != null){
            txtNome.setText(evento.getNome());
            txtDescricao.setText(evento.getDescricao());
            txtHoraFinal.setText(evento.getHoraFinal());
            txtHoraInicio.setText(evento.getHoraInicio());
            txtData.setText(evento.getData());
            txtLocal.setText(evento.getLocal());
        }else{
            btnExcluir.setVisibility(View.GONE);
            evento = new Evento();
        }
    }

    public void excluir(View view){
        new AlertDialog.Builder(this)
                .setTitle("Atenção")
                .setMessage("Você deseja excluir?")
                .setIcon(
                        getResources().getDrawable(
                                android.R.drawable.ic_dialog_alert))
                .setPositiveButton("Sim",
                        new DialogInterface.OnClickListener() {

                            @Override
                            public void onClick(DialogInterface dialog,
                                                int which) {
                                if(controller.delete(evento.getId())){
                                    Snackbar.make(getCurrentFocus(), "Excluído com sucesso", Snackbar.LENGTH_INDEFINITE)
                                            .setAction("Ok", new View.OnClickListener() {
                                                @Override
                                                public void onClick(View view) {
                                                    closeActivity();
                                                }
                                            }).show();
                                }else{
                                    Snackbar.make(getCurrentFocus(), "Error. Um ou mais checklist podem está associados.", Snackbar.LENGTH_LONG)
                                            .setAction("Ok", null).show();
                                }
                            }
                        })
                .setNegativeButton("Não", null).show();
    }

    public void manter(View view){
        if(StringUtility.isValid(this.txtNome)
                && StringUtility.isValid(this.txtDescricao)
                && StringUtility.isValid(this.txtData)
                && StringUtility.isValid(this.txtHoraFinal)
                && StringUtility.isValid(this.txtHoraInicio)
                && StringUtility.isValid(this.txtLocal)) {

            evento.setNome(this.txtNome.getText().toString());
            evento.setDescricao(this.txtDescricao.getText().toString());
            evento.setData(this.txtData.getText().toString());
            evento.setHoraFinal(this.txtHoraFinal.getText().toString());
            evento.setHoraInicio(this.txtHoraInicio.getText().toString());
            evento.setLocal(this.txtLocal.getText().toString());

            if(evento != null && evento.getId() > 0){
                if(this.controller.update(evento)){
                    Snackbar.make(view, "Cadastro atualizado com sucesso", Snackbar.LENGTH_INDEFINITE)
                            .setAction("Ok", new View.OnClickListener() {
                                @Override
                                public void onClick(View view) {
                                    closeActivity();
                                }
                            }).show();
                }else{
                    Snackbar.make(view, "Atualização não realizada", Snackbar.LENGTH_LONG)
                            .show();
                }

            }else{
                if(this.controller.create(evento)){
                    Snackbar.make(view, "Cadastro efetuado com sucesso", Snackbar.LENGTH_INDEFINITE)
                            .setAction("Ok", new View.OnClickListener() {
                                @Override
                                public void onClick(View view) {
                                    closeActivity();
                                }
                            }).show();
                }else{
                    Snackbar.make(view, "Cadastro não efetuado", Snackbar.LENGTH_LONG)
                            .show();
                }

            }
        }else{
            Snackbar.make(view, "Todos os campos devem ser preenchidos", Snackbar.LENGTH_LONG)
                        .setAction("Ok", null).show();
        }
    }

    private void closeActivity(){
        super.finish();
    }

    private void formatDate(final EditText editText){
        final Calendar myCalendar = Calendar.getInstance();

        final DatePickerDialog.OnDateSetListener date = new DatePickerDialog.OnDateSetListener() {

            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear,
                                  int dayOfMonth) {
                // TODO Auto-generated method stub
                myCalendar.set(Calendar.YEAR, year);
                myCalendar.set(Calendar.MONTH, monthOfYear);
                myCalendar.set(Calendar.DAY_OF_MONTH, dayOfMonth);

                String myFormat = "dd/MM/yy"; //In which you need put here
                SimpleDateFormat sdf = new SimpleDateFormat(myFormat, Locale.US);

                editText.setText(sdf.format(myCalendar.getTime()));
            }

        };

        editText.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                new DatePickerDialog(EventoDetalheActivity.this, date, myCalendar
                        .get(Calendar.YEAR), myCalendar.get(Calendar.MONTH),
                        myCalendar.get(Calendar.DAY_OF_MONTH)).show();
            }
        });
    }

    private void formatTime(final EditText editText){
        final Calendar myCalendar = Calendar.getInstance();

        final TimePickerDialog.OnTimeSetListener date = new TimePickerDialog.OnTimeSetListener() {


            @Override
            public void onTimeSet(TimePicker timePicker, int hora, int minuto) {
                myCalendar.set(Calendar.HOUR_OF_DAY, hora);
                myCalendar.set(Calendar.MINUTE, minuto);

                String myFormat = "hh:mm";
                SimpleDateFormat sdf = new SimpleDateFormat(myFormat, Locale.US);
                editText.setText(sdf.format(myCalendar.getTime()).toString());
            }
        };


        editText.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                new TimePickerDialog(EventoDetalheActivity.this, date, myCalendar
                        .get(Calendar.HOUR_OF_DAY), myCalendar.get(Calendar.MINUTE), false).show();
            }
        });
    }
}
