// stores/note.js
import { defineStore } from 'pinia'
const apiUrl = import.meta.env.VITE_API_URL;
const token = localStorage.getItem('token');

export const useNoteStore = defineStore('note', {

    state: () => ({
        isOpen: false,
        isEdit: false,
        notes: [],
        note: null
    }),

    actions: {
        async getAllNotes() {
            try {

                const response = await fetch(`${apiUrl}/api/note`, {
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    }
                });
                if (response.status == 200) {
                    const content = await response.json();
                    this.notes = content;
                }
            } catch (e) {

            }
        },

        async getNote(id: string) {
            try {

                const response = await fetch(`${apiUrl}/api/note/${id}`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    }
                });

                if (response.status == 200) {
                    this.note = await response.json();

                }

            } catch (e) {

            }
        },

        async createNote(data: any) {
            try {

                const res = await fetch(`${apiUrl}/api/note`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    },
                    body: JSON.stringify(data)
                });

                if (res.status == 200) {
                    this.isOpen = false;
                    this.note = {
                        title: '',
                        content: ''
                    };
                    await this.getAllNotes();
                }

            } catch (e) {

            }
        },

        async updateNote(id: string, data: any) {
            try {

                const res = await fetch(`${apiUrl}/api/note/${id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    },
                    body: JSON.stringify(data)
                });

                if (res.status == 200) {
                    this.isEdit = false;
                    await this.getAllNotes();
                }

            } catch (e) {

            }
        },

        async deletNote(id: string) {
            try {

                const res = await fetch(`${apiUrl}/api/note/${id}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    }
                });

                if (res.status == 200) {
                    await this.getAllNotes();
                }

            } catch (e) {

            }
        }

    },
})
