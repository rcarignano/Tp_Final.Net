<script setup lang="ts">
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Button from 'primevue/button';
const clientData = [{id_cliente: 1, nombre : "Romi", direccion: "Calle falsa 123", ciudad: "San Pancha", provincia : "Cba", zona:"Sudeste"}, {id_cliente: 1, nombre : "Romi", direccion: "Calle falsa 123", ciudad: "San Pancha", provincia : "Cba", zona:"Sudeste"}];
</script>

<template>
  <div class="">
   <DataTable :value="clientData" tableStyle="min-width: 50rem">
    <template #header>
      <div>
        <div class="flex flex-wrap align-items-center justify-content-between gap-2">
          <span class="text-xl text-900 font-bold">Clientes</span>
        </div>
      </div>
    </template>
    <Column field="id_cliente" header="Id Cliente"></Column>
    <Column field="nombre" header="Nombre"></Column>
    <Column field="direccion" header="Dirección"></Column>
    <Column field="ciudad" header="Ciudad"></Column>
  </DataTable>
  </div>
</template>

<style scoped>

</style>
