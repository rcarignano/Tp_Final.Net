<template>
  <div class="grid">
    <div class="col-12">
      <div class="card">
        <Card>
          <template #title>Clientes</template>
          <template #content>
            <div class="p-fluid">
              <div class="p-field">
                <label for="searchQuery">Buscar:</label>
                <InputText v-model="clientId" id="clientId" placeholder="Ingrese un Id"/>
              </div>
              <div class="p-field button-container">
                <Button label="Lista Clientes" @click="searchClients" class="p-button-sm" />
                <Button label="Buscar por Id" @click="searchClientById()" class="p-button-sm" :disabled="isClientIdEmpty || !isClientIdNumber" />
              </div>
            </div>
          </template>
        </Card>
      </div>
    </div>
    <div class="mb-3"></div>
    <div class="grid">
      <div class="col-12">
        <DataTable :value="clients">
          <Column field="clientId" header="ID Cliente"></Column>
          <Column field="name" header="Nombre"></Column>
          <Column field="streetName" header="Direccion"></Column>
          <Column field="city" header="Ciudad"></Column>
          <Column field="province" header="Provincia"></Column>
        </DataTable>
      </div>
    </div>
  </div>

  <div class="error-alert" v-if="validationErrors.length > 0">
  <ul>
    <li v-for="error in validationErrors" :key="error">
      {{ error }}
    </li>
  </ul>
</div>
</template>


<script setup lang="ts">
import { ref,watchEffect  } from 'vue';
import axios from 'axios';
import Card from 'primevue/card';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';

const clients = ref([]) as any;
const clientId = ref('');
const validationErrors = ref<string[]>([]);
const isClientIdEmpty = ref(true);
const isClientIdNumber = ref(true);

const searchClients = async () => {
  try {
    const response = await axios.get('http://localhost:5000/api/v1/client');
    clients.value = response.data.clientList;
  } catch (error : any) {
    console.error('Error al buscar cliente:', error);
  }
};

const searchClientById = async () => {
  try {
    const response = await axios.get(`http://localhost:5000/api/v1/client/${clientId.value}`);
    const client = response.data.client;
    clients.value = [client];
    validationErrors.value = [];
  } catch (error : any) {
    if (error.response && error.response.status === 422 && error.response.data.errors && error.response.data.errors.ClientId) {
      const errorMessage = 'El ID del cliente no se encuentra dentro de los permitidos por la base.';
      validationErrors.value = [errorMessage];
      console.error('Validation error:', errorMessage);
    } else {
      console.error('Error fetch de cliente:', error.response ? error.response.data : error.message);
      validationErrors.value = ['El ID del cliente no se encuentra dentro de los permitidos por la base.'];
    }
  }
};

watchEffect(() => {
  const trimClientId = clientId.value.trim();
  isClientIdEmpty.value = clientId.value.trim() === '';
  isClientIdEmpty.value = trimClientId === '';
  isClientIdNumber.value = /^\d+$/.test(trimClientId);
});
</script>

<style scoped>
.button-container {
  display: flex;
  gap: 8px;
}
.p-button-sm {
  font-size: 12px;
  padding: 6px 10px;
}
.error-alert {
  background-color: #ffdddd;
  color: #721c24;
  padding: 10px;
  border: 1px solid #f5c6cb;
  border-radius: 5px;
  margin-bottom: 10px;}
</style>
