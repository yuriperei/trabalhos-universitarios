package br.com.alfred.alfred.View.Checklist;


import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.List;

import br.com.alfred.alfred.Adapter.EventoAdapter;
import br.com.alfred.alfred.Controller.EventoController;
import br.com.alfred.alfred.Model.Evento;
import br.com.alfred.alfred.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class ChecklistFragment extends Fragment {

    private View view;
    private EventoController controller;
    private ListView listView;
    private EventoAdapter adapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        //getActivity().setTitle();
        this.controller = new EventoController(getContext());

        if(view==null)
        {
            view= inflater.inflate(R.layout.fragment_checklist, container, false);
        }
        else
        {
            ViewGroup parent = (ViewGroup) view.getParent();
            parent.removeView(view);
        }

        listView = (ListView) view.findViewById(R.id.listView);
        TextView msg = (TextView) view.findViewById(R.id.msg);

        List<Evento> eventos = this.controller.getEventos();
        if(eventos.isEmpty()){
            msg.setText("Não há eventos cadastrados");
        }

        adapter = new EventoAdapter(getActivity(), eventos);

        listView.setAdapter(adapter);
        listView.setOnItemClickListener(onClickItem);

        return view;
    }

    private AdapterView.OnItemClickListener onClickItem = new AdapterView.OnItemClickListener(){

        @Override
        public void onItemClick(AdapterView<?> adapterView, View view, int position, long id) {
            Intent i = new Intent(getActivity(), ChecklistActivity.class);
            Evento evento = (Evento) listView.getItemAtPosition(position);
            i.putExtra("evento", evento);
            startActivity(i);
        }
    };
}
