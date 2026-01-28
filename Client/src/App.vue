<template>
  <div class="app-container">
    <nav class="sidebar">
      <h3>Phone Book</h3>
      <div class="menu-links">
        <router-link to="/entity-management" class="menu-item">Entity Management</router-link>
        <router-link to="/web-service-ops" class="menu-item">Web Service Ops</router-link>
      </div>
    </nav>

    <main class="content">
      <router-view />
    </main>
  </div>
</template>

<style>
body { margin: 0; padding: 0; font-family: 'Segoe UI', sans-serif; box-sizing: border-box; }

.app-container { display: flex; height: 100vh; width: 100vw; }

.sidebar {
  width: 260px;
  background-color: #1e293b;
  color: white;
  display: flex;
  flex-direction: column;
  padding: 20px;
  border-right: 1px solid #334155;
}

.sidebar h3 { margin-bottom: 30px; text-align: center; color: #38bdf8; }

.menu-links { display: flex; flex-direction: column; gap: 10px; }

.menu-item {
  text-decoration: none;
  color: #cbd5e1;
  padding: 12px;
  border-radius: 6px;
  transition: all 0.3s;
  background-color: #334155;
}

.menu-item:hover, .router-link-active {
  background-color: #0ea5e9; 
  color: white;
  transform: translateX(5px);
}


.content {
  flex: 1;
  padding: 40px;
  background-color: #f1f5f9; 
  overflow-y: auto;
}
</style>