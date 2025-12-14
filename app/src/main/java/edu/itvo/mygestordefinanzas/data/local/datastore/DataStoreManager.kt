package edu.itvo.mygestordefinanzas.data.local.datastore

import android.content.Context
import androidx.datastore.preferences.core.*
import androidx.datastore.preferences.preferencesDataStore
import dagger.hilt.android.qualifiers.ApplicationContext
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.map
import javax.inject.Inject
import javax.inject.Singleton

private val Context.dataStore by preferencesDataStore(name = "user_preferences")

@Singleton
class DataStoreManager @Inject constructor(
    @ApplicationContext private val context: Context
) {

    companion object {
        val NAME = stringPreferencesKey("name")
        val EMAIL = stringPreferencesKey("email")
        val AGE = intPreferencesKey("age")
        val IS_LOGGED_IN = booleanPreferencesKey("is_logged_in")
        val DARK_THEME = booleanPreferencesKey("dark_theme")
        val NOTIFICATIONS = booleanPreferencesKey("notifications")
    }

    val preferencesFlow: Flow<Preferences> = context.dataStore.data

    suspend fun saveUser(name: String, email: String, age: Int) {
        context.dataStore.edit {
            it[NAME] = name
            it[EMAIL] = email
            it[AGE] = age
            it[IS_LOGGED_IN] = true
        }
    }

    suspend fun logout() {
        context.dataStore.edit {
            it[IS_LOGGED_IN] = false
        }
    }

    suspend fun updateDarkTheme(enabled: Boolean) {
        context.dataStore.edit {
            it[DARK_THEME] = enabled
        }
    }

    suspend fun updateNotifications(enabled: Boolean) {
        context.dataStore.edit {
            it[NOTIFICATIONS] = enabled
        }
    }
}
