package edu.itvo.mygestordefinanzas.domain.usecase

import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import javax.inject.Inject
import kotlinx.coroutines.flow.first


class UpdateNotificationsUseCase @Inject constructor(
    private val repository: UserRepository
) {
    suspend operator fun invoke(enabled: Boolean) {
        repository.saveUserPreferences(
            repository.getUserPreferences()
                .first()
                .copy(notificationsEnabled = enabled)
        )

        }
    }


