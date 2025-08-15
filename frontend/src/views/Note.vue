<template>
    <CreateNote v-if="noteStore.isOpen" />
    <EditNote v-if="noteStore.isEdit" />

    <div class="text-right">
        <button type="button" @click="noteStore.isOpen = true"
            class="cursor-pointer inline-block bg-green-600 rounded-full px-3 py-1 text-sm font-semibold text-white mr-2 mb-2">New</button>
    </div>

    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-3 bg-gray-100">
        <div v-for="note in noteStore.notes" :key="note.id" class="rounded overflow-hidden shadow-lg bg-white">
            <div class="px-6 py-4">
                <div class="font-bold text-xl mb-2">{{ note.title }}</div>
                <p class="text-gray-700 text-base">
                    {{ note.content }}
                </p>
                <p class="text-gray-700 text-base">
                    {{ note.user.username }}
                </p>
            </div>
            <div class="px-6 pt-4 pb-2">
                <button @click="editNote(note.id)"
                    class="cursor-pointer inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">
                    {{ 'Edit' }}
                </button>
                <button @click="deletNote(note.id)"
                    class="cursor-pointer inline-block bg-red-500  rounded-full px-3 py-1 text-sm font-semibold text-white mr-2 mb-2">
                    {{ 'Delete' }}
                </button>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { onMounted, ref } from 'vue';
import CreateNote from '@/components/CreateNote.vue';
import EditNote from '@/components/EditNote.vue';
import { useNoteStore } from '@/store/note';



export default {
    components: { CreateNote, EditNote },
    name: "Note",
    setup() {
        const noteStore = useNoteStore();

        onMounted(async () => {
            await noteStore.getAllNotes();
        });

        const editNote = async (id: string) => {
            noteStore.isEdit = true;
            await noteStore.getNote(id);

        };

        const deletNote = async (id: string) => {
            if (confirm("Are you sure you want to delete?")) {
                noteStore.deletNote(id);
            }
        };

        return {
            noteStore,
            editNote,
            deletNote
        }
    }
}
</script>