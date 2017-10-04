package br.com.alfred.alfred.View.Checklist;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.List;

import br.com.alfred.alfred.Adapter.ChecklistAdapter;
import br.com.alfred.alfred.Controller.ChecklistController;
import br.com.alfred.alfred.Model.Checklist;
import br.com.alfred.alfred.Model.Evento;
import br.com.alfred.alfred.R;

public class ChecklistActivity extends AppCompatActivity {

    private ChecklistController controller;
    private ListView listView;
    private ChecklistAdapter adapter;
    public Evento evento;

    @Override
    public void onResume() {
        List<Checklist> checklists = this.controller.getCheckLists(evento.getId());
        if(!checklists.isEmpty()){
            findViewById(R.id.msg).setVisibility(View.GONE);
        }
        adapter = new ChecklistAdapter(ChecklistActivity.this, checklists);

        listView.setAdapter(adapter);
        super.onResume();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_checklist);

        this.controller = new ChecklistController(getApplicationContext());

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(ChecklistActivity.this, ChecklistDetalheActivity.class);
                i.putExtra("evento", evento);
                startActivity(i);
            }
        });

        listView = (ListView) findViewById(R.id.listView);
        Intent intent = getIntent();
        evento = (Evento) intent.getSerializableExtra("evento");

        List<Checklist> checklists = this.controller.getCheckLists(evento.getId());
        if(!checklists.isEmpty()){
            findViewById(R.id.msg).setVisibility(View.GONE);
        }
        adapter = new ChecklistAdapter(ChecklistActivity.this, checklists);

        listView.setAdapter(adapter);
        listView.setOnItemClickListener(onClickItem);
    }

    private AdapterView.OnItemClickListener onClickItem = new AdapterView.OnItemClickListener(){

        @Override
        public void onItemClick(AdapterView<?> adapterView, View view, int position, long id) {
            Intent i = new Intent(ChecklistActivity.this, ChecklistDetalheActivity.class);
            Checklist checklist = (Checklist) listView.getItemAtPosition(position);
            i.putExtra("evento", evento);
            i.putExtra("checklist", checklist);
            startActivity(i);
        }
    };
}
