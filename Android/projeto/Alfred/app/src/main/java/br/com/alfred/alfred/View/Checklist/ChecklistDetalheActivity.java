package br.com.alfred.alfred.View.Checklist;

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
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.TimePicker;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;

import br.com.alfred.alfred.Controller.ChecklistController;
import br.com.alfred.alfred.Model.Checklist;
import br.com.alfred.alfred.Model.Evento;
import br.com.alfred.alfred.R;
import br.com.alfred.alfred.Util.StringUtility;

public class ChecklistDetalheActivity extends AppCompatActivity {

    private Checklist checklist;
    private Evento evento;

    public ChecklistController controller;

    EditText txtNome;
    EditText txtData;
    EditText txtHora;
    CheckBox checkFeito;
    TextView lblFeito;
    Button btnExcluir;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_checklist_detalhe);

        this.controller = new ChecklistController(this);

        Intent intent = getIntent();
        evento = (Evento) intent.getSerializableExtra("evento");
        checklist = (Checklist) intent.getSerializableExtra("checklist");

        btnExcluir = (Button) findViewById(R.id.button_excluir);

        txtNome = (EditText) findViewById(R.id.txtNome);
        txtData = (EditText) findViewById(R.id.txtData);
        formatDate(txtData);

        txtHora = (EditText) findViewById(R.id.txtHora);
        formatTime(txtHora);

        lblFeito = (TextView) findViewById(R.id.lblFeito);
        checkFeito = (CheckBox) findViewById(R.id.checkFeito);

        if(checklist != null){
            txtNome.setText(checklist.getNome());
            txtData.setText(checklist.getData());
            txtHora.setText(checklist.getHora());
            checkFeito.setChecked((checklist.getFeito() != 0));
        }else{
            btnExcluir.setVisibility(View.GONE);
            lblFeito.setVisibility(View.GONE);
            checkFeito.setVisibility(View.GONE);
            checklist = new Checklist();
            checkFeito.setChecked(false);
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
                                controller.delete(checklist.getId());
                                Snackbar.make(null, "Excluído com sucesso", Snackbar.LENGTH_SHORT).show();
                                closeActivity();
                            }
                        })
                .setNegativeButton("Não", null).show();
    }

    public void manter(View view){
        if(StringUtility.isValid(this.txtNome)
                && StringUtility.isValid(this.txtHora)
                && StringUtility.isValid(this.txtData)) {

            checklist.setNome(this.txtNome.getText().toString());
            checklist.setData(this.txtData.getText().toString());
            checklist.setHora(this.txtHora.getText().toString());
            checklist.setFeito(convertBooleanToInt(this.checkFeito.isChecked()));
            checklist.setCodEvento(evento.getId());

            if(checklist != null && checklist.getId() > 0){
                if(this.controller.update(checklist)){
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
                if(this.controller.create(checklist)){
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

    private int convertBooleanToInt(boolean bool){
        if(bool){
            return 1;
        }else{
            return 0;
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
                new DatePickerDialog(ChecklistDetalheActivity.this, date, myCalendar
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
                new TimePickerDialog(ChecklistDetalheActivity.this, date, myCalendar
                        .get(Calendar.HOUR_OF_DAY), myCalendar.get(Calendar.MINUTE), false).show();
            }
        });
    }
}
