<template>
  <div class="page-container">
    <h2>Entity Management</h2>

    <div class="card form-section">
      <h3>Add New Record</h3>
      <div class="form-grid">
        <input v-model="newPerson.name" placeholder="Name" />
        <input v-model="newPerson.surname" placeholder="Surname" />
        <input v-model="newPerson.age" type="number" placeholder="Age" />
        <input v-model="newPerson.email" placeholder="Email" />
        <input v-model="newPerson.phoneNumber" placeholder="Phone Number" />
        <button @click="addRecord" class="btn-primary">Add Record</button>
      </div>
    </div>

    <div class="card list-section">
      <div class="search-bar">
        <input v-model="searchQuery" placeholder="Search by Name or Phone..." />
        <button @click="searchRecords" class="btn-secondary">Search</button>
        <button @click="fetchRecords" class="btn-outline">List All / Reset</button>
      </div>

      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Surname</th>
            <th>Age</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          <tr v-if="persons.length === 0">
            <td colspan="6" style="text-align:center;">No records found.</td>
          </tr>
          <tr v-for="person in persons" :key="person.id">
            <td>{{ person.name }}</td>
            <td>{{ person.surname }}</td>
            <td>{{ person.age }}</td>
            <td>{{ person.email }}</td>
            <td>{{ person.phoneNumber }}</td>
            <td>
              <button @click="deleteRecord(person.name)" class="btn-danger">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';


const API_URL = 'https://localhost:7033/api/entity'; 

const persons = ref([]);
const searchQuery = ref('');
const newPerson = ref({
  name: '', surname: '', age: '', email: '', phoneNumber: ''
});


const fetchRecords = async () => {
  try {
    const response = await axios.get(`${API_URL}/list`);
    persons.value = response.data;
  } catch (error) {
    console.error("Listeleme Hatası:", error);
    alert("Veriler çekilemedi! Backend çalışıyor mu?");
  }
};

const addRecord = async () => {
  if(!newPerson.value.name || !newPerson.value.phoneNumber) {
    alert("İsim ve Telefon zorunludur!");
    return;
  }
  try {
    await axios.post(`${API_URL}/add`, newPerson.value);
    alert("Kayıt Eklendi!");
 
    newPerson.value = { name: '', surname: '', age: '', email: '', phoneNumber: '' };
    fetchRecords();
  } catch (error) {
    console.error("Ekleme Hatası:", error);
    alert("Ekleme başarısız.");
  }
};


const deleteRecord = async (name) => {
  if(!confirm(`${name} isimli kaydı silmek istediğinize emin misiniz?`)) return;
  
  try {
    await axios.delete(`${API_URL}/delete/${name}`);
    fetchRecords(); 
  } catch (error) {
    console.error("Silme Hatası:", error);
    alert("Silme başarısız.");
  }
};

const searchRecords = async () => {
  if (!searchQuery.value) {
    fetchRecords();
    return;
  }
  try {
    const response = await axios.get(`${API_URL}/search/${searchQuery.value}`);
    persons.value = response.data;
  } catch (error) {
    console.error("Arama Hatası:", error);
  }
};

onMounted(fetchRecords);
</script>

<style scoped>
.page-container { max-width: 1000px; margin: 0 auto; }
h2 { color: #333; border-bottom: 2px solid #0ea5e9; padding-bottom: 10px; margin-bottom: 20px; }

.card { background: white; padding: 20px; border-radius: 8px; box-shadow: 0 2px 5px rgba(0,0,0,0.1); margin-bottom: 20px; }


.form-grid { display: grid; grid-template-columns: repeat(auto-fit, minmax(150px, 1fr)); gap: 10px; align-items: end; }
input { padding: 10px; border: 1px solid #ddd; border-radius: 5px; width: 100%; box-sizing: border-box; }

button { padding: 10px 15px; border: none; border-radius: 5px; cursor: pointer; font-weight: bold; transition: 0.2s; }
.btn-primary { background: #0ea5e9; color: white; }
.btn-secondary { background: #64748b; color: white; }
.btn-outline { background: transparent; border: 1px solid #64748b; color: #64748b; }
.btn-danger { background: #ef4444; color: white; padding: 5px 10px; font-size: 0.9em; }

button:hover { opacity: 0.9; }

.search-bar { display: flex; gap: 10px; margin-bottom: 15px; }
table { width: 100%; border-collapse: collapse; margin-top: 10px; }
th { background: #f8fafc; text-align: left; padding: 12px; border-bottom: 2px solid #e2e8f0; color: #475569; }
td { padding: 12px; border-bottom: 1px solid #e2e8f0; }
tr:hover { background: #f1f5f9; }
</style>