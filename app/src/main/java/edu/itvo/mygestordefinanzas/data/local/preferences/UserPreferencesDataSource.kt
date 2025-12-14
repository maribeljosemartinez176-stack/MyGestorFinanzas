package edu.itvo.mygestordefinanzas.data.local.preferences

import edu.itvo.mygestordefinanzas.data.local.datastore.DataStoreManager
import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.map
import javax.inject.Inject
import javax.inject.Singleton

@Singleton
class UserPreferencesDataSource @Inject constructor(
    private val dataStoreManager: DataStoreManager
) {

    fun getUserPreferences(): Flow<UserPreferences> {
        return dataStoreManager.preferencesFlow.map { prefs ->
            UserPreferences(
                name = prefs[DataStoreManager.NAME] ?: "",
                email = prefs[DataStoreManager.EMAIL] ?: "",
                age = prefs[DataStoreManager.AGE] ?: 0,
                isLoggedIn = prefs[DataStoreManager.IS_LOGGED_IN] ?: false,
                darkTheme = prefs[DataStoreManager.DARK_THEME] ?: false,
                notificationsEnabled = prefs[DataStoreManager.NOTIFICATIONS] ?: true
            )
        }
    }

    suspend fun saveUser(name: String, email: String, age: Int) {
        dataStoreManager.saveUser(name, email, age)
    }

    suspend fun updateDarkTheme(enabled: Boolean) {
        dataStoreManager.updateDarkTheme(enabled)
    }

    suspend fun updateNotifications(enabled: Boolean) {
        dataStoreManager.updateNotifications(enabled)
    }

    suspend fun logout() {
        dataStoreManager.logout()
    }
}

