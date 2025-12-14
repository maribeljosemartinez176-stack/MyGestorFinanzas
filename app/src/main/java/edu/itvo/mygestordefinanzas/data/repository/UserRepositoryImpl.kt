package edu.itvo.mygestordefinanzas.data.repository

import edu.itvo.mygestordefinanzas.data.local.preferences.UserPreferencesDataSource
import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import kotlinx.coroutines.flow.Flow
import javax.inject.Inject

class UserRepositoryImpl @Inject constructor(
    private val dataSource: UserPreferencesDataSource
) : UserRepository {

    override fun getUserPreferences(): Flow<UserPreferences> =
        dataSource.getUserPreferences()

    override suspend fun saveUserPreferences(preferences: UserPreferences) {
        dataSource.saveUser(
            preferences.name,
            preferences.email,
            preferences.age
        )
        dataSource.updateDarkTheme(preferences.darkTheme)
        dataSource.updateNotifications(preferences.notificationsEnabled)
    }

    override suspend fun clear() {
        dataSource.logout()
    }
}


