package br.com.alfred.alfred.View.Evento;


import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import br.com.alfred.alfred.Adapter.EventoAdapter;
import br.com.alfred.alfred.Controller.EventoController;
import br.com.alfred.alfred.Model.Evento;
import br.com.alfred.alfred.R;


/**
 * A simple {@link Fragment} subclass.
 */
public class EventoFragment extends Fragment {

    private View view;
    private EventoController controller;
    private ListView listView;
    private EventoAdapter adapter;

    @Override
    public void onResume() {
        adapter = new EventoAdapter(getActivity(), this.controller.getEventos());
        listView.setAdapter(adapter);
        super.onResume();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        this.controller = new EventoController(getContext());

        if(view==null)
        {
            view=inflater.inflate(R.layout.fragment_evento, container,false);
        }
        else
        {
            ViewGroup parent = (ViewGroup) view.getParent();
            parent.removeView(view);
        }

        FloatingActionButton fab = (FloatingActionButton) view.findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(getActivity(), EventoDetalheActivity.class);
               startActivity(i);
            }
        });

        listView = (ListView) view.findViewById(R.id.listView);

        adapter = new EventoAdapter(getActivity(), this.controller.getEventos());

        listView.setAdapter(adapter);
        listView.setOnItemClickListener(onClickItem);

        return view;
    }

    private AdapterView.OnItemClickListener onClickItem = new AdapterView.OnItemClickListener(){

        @Override
        public void onItemClick(AdapterView<?> adapterView, View view, int position, long id) {
            Intent i = new Intent(getActivity(), EventoDetalheActivity.class);
            Evento evento = (Evento) listView.getItemAtPosition(position);
            i.putExtra("evento", evento);
            startActivity(i);
        }
    };

}
