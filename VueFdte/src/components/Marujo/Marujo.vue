<template>
  <div class="container">
    <br/>
    <div class="row">
      <div class="col-md-12 text-center">
        <h3>Lista de Marujo</h3>
      </div>
    </div>
    <br/>
    <br/>
    <div class="row">
      <div class="col-md-12 text-left">
        <a href="#" @click="showAddModal=true">
          <span class="btn btn-primary">Add New Marujo</span>
        </a>
      </div>
    </div>
    <br/>
    <div class="row">
      <div class="col-md-12">
        <div class="table-responsive">
          <table id="studentTable" class="table table-dark table-borded table-striped table-hover">
            <thead>
            <th>Code</th>
            <th>First Name</th>
            <th>Last Name</th>
            </thead>
            <tbody>
            <tr v-for="(row) in marujos" :key="row['id']">
              <td>{{ row['id']}}</td>
              <td>{{ row['firstName'] }}</td>
              <td>{{ row['lastName'] }}</td>
              <td class="text-center">
                <a href="#" @click="showEditModal=true; getMarujo(row['id']);">
                  <span class="btn btn-primary btn-xs">Edit</span>
                </a>
              </td>
              <td class="text-center">
                <a href="#" @click="showDeleteModal=true; getMarujo(row['id']);">
                  <span class="btn btn-danger btn-xs">Delete</span>
                </a>
              </td>
            </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

    <!-- Add marujo Modal -->
    <div class="overlay" v-if="showAddModal">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Add Marujo</h5>
            <button type="button" class="close" @click="showAddModal=false; clearForm();">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body p-4">
            <form action="#" method="post">
              <div class="form-group text-left">
                <label>First Name</label>
                <input type="text" class="form-control" name="firstName" placeholder="Enter First Name"
                       v-model="newMarujo.firstName"/>
              </div>
              <div class="form-group text-left">
                <label>Last Name</label>
                <input type="text" class="form-control" name="lastName" placeholder="Enter Last Name"
                       v-model="newMarujo.lastName"/>
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" @click="showAddModal=false;">Close</button>
            <button :disabled="!newMarujo.firstName || !newMarujo.lastName" type="submit" class="btn btn-primary"
                    @click="showAddModal=false; addMarujo();">
              Save
            </button>
          </div>
        </div>
      </div>
    </div>
    <!-- End of marujo modal -->

    <!-- Edit marujo Modal -->
    <div class="overlay" v-if="showEditModal">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Edit Marujo</h5>
            <button type="button" class="close" @click="showEditModal=false">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body p-4">
            <form action="#" method="post">
              <div class="form-group text-left">
                <label>First Name</label>
                <input type="text" class="form-control" name="firstName" placeholder="Enter First Name"
                       v-model="currentMarujo.firstName"/>
              </div>
              <div class="form-group text-left">
                <label>Last Name</label>
                <input type="text" class="form-control"  name="lastName" placeholder="Enter Last Name"
                       v-model="currentMarujo.lastName"/>
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" @click="showEditModal=false">Close</button>
            <button :disabled="!currentMarujo.firstName || !currentMarujo.lastName" type="submit" class="btn btn-primary" @click="showEditModal=false; updateMarujo();">
              Save
            </button>
          </div>
        </div>
      </div>
    </div>
    <!-- End of edit marujo modal -->

    <!-- Delete marujo Modal -->
    <div class="overlay" v-if="showDeleteModal">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Delete Marujo</h5>
            <button type="button" class="close" @click="showDeleteModal=false">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body p-4">
            <form action="#" method="post">
              <div class="form-group text-left">
                <label class="col-sm-12 control-label">Are you sure to delete following
                  marujo?</label>
              </div>
              <div class="form-group text-left">
                <label class="col-sm-12 control-label" style="color:blue;">
                  {{currentMarujo.firstName}}
                </label>
              </div>
              <br>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-info" @click="showDeleteModal=false">No</button>
            <button type="submit" class="btn btn-danger" @click="showDeleteModal=false; deleteMarujo();">
              Yes
            </button>
          </div>
        </div>
      </div>
    </div>
    <!-- End of delete marujo modal -->
  </div>
</template>

<style type="text/css">
  .overlay {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.6);
  }
</style>

<script>
  import MarujoService from "./services/marujoService";

  export default {
    name: "marujo",
    data() {
      return {
        marujos: null,
        loading: false,
        currentMarujo: {},
        message: null,
        newMarujo: {
          firstName: null,
          lastName: null
        },
        showAddModal: false,
        showEditModal: false,
        showDeleteModal: false,
      };
    },
    // computed: {
    //   isDisabled: function() {
    //     return this.newMarujo.firstName === 0;
    //   }
    // },
    async created() {
      this.getMarujoList();
    },
    methods: {
      async getMarujoList() {
        this.marujos = await MarujoService.getAll();
      },

      async addMarujo() {
        await MarujoService.create(this.newMarujo);
        await this.getMarujoList();
      },

      async getMarujo(id) {
        this.currentMarujo = await MarujoService.get(id);
      },

      async updateMarujo() {
        await MarujoService.update(this.currentMarujo);
        await this.getMarujoList();
      },

      async deleteMarujo() {
        const idStudent = this.currentMarujo.id;
        await MarujoService.delete(idStudent);
        await this.getMarujoList();
      },

      async clearForm() {
        this.currentMarujo.firstName = null;
        this.currentMarujo.lastName = null;
      }
    }
  };
</script>
