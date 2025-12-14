package edu.itvo.mygestordefinanzas.domain.repository


import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import kotlinx.coroutines.flow.Flow

interface UserRepository {
    fun getUserPreferences(): Flow<UserPreferences>

    suspend fun saveUserPreferences(preferences: UserPreferences)
    suspend fun clear()
}
